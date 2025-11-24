using AutoMapper;
using System.Reflection;
using UniConnect.Argument;
using UniConnect.Domain.Entity;
using UniConnect.Domain.Interface.Repository;
using UniConnect.Domain.Interface.Service;

namespace UniConnect.Domain.Service;

public abstract class BaseService<TRepository, TEntity, TInputCreate, TInputUpdate, TInputDelete, TOutput> : IBaseService<TInputCreate, TInputUpdate, TInputDelete, TOutput>
        where TRepository : IBaseRepository<TEntity>
        where TEntity : BaseEntity<TEntity>, new()
        where TInputCreate : BaseInputCreate<TInputCreate>
        where TInputUpdate : BaseInputUpdate<TInputUpdate>
        where TInputDelete : BaseInputDelete<TInputDelete>
        where TOutput : BaseOutput<TOutput>
{
    protected readonly TRepository _repository;
    protected readonly IMapper _mapper;

    public BaseService(TRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    #region Create
    public virtual int Create(TInputCreate? inputCreate)
    {
        return CreateMultiple([inputCreate])?.FirstOrDefault() ?? 0;
    }

    public virtual List<int>? CreateMultiple(List<TInputCreate>? listInputCreate)
    {
        List<TEntity> listCreate = new List<TEntity>();

        OnCreateMultiple(listInputCreate);

        foreach (var i in listInputCreate)
        {
            TEntity instance = new TEntity();
            foreach (PropertyInfo inputPropertyInfo in typeof(TInputCreate).GetProperties())
            {
                PropertyInfo? propertyInfo = typeof(TEntity).GetProperty(inputPropertyInfo.Name);
                if (propertyInfo != null)
                    propertyInfo.SetValue(instance, inputPropertyInfo.GetValue(i));
            }
            listCreate.Add(instance);
        }

        List<int> listId = _repository.CreateMultiple(listCreate);
        return listId;
    }

    protected virtual void OnCreateMultiple(List<TInputCreate>? listInputCreate) { }
    #endregion

    #region Delete
    public bool Delete(TInputDelete? inputDelete)
    {
        return DeleteMultiple([inputDelete]);
    }

    public bool DeleteMultiple(List<TInputDelete>? listInputDelete)
    {
        if (listInputDelete == null)
            throw new Exception("Lista inválida");

        List<TEntity> listDelete = _repository.GetListByListId((from i in listInputDelete ?? [] select i.Id).ToList()!)!;
        foreach (var i in listInputDelete!)
        {
            TEntity? originalEntity = (from j in listDelete where i.Id == j.Id select j).FirstOrDefault();
            if (originalEntity == null)
                throw new Exception($"Registro id {i.Id} inexistente");
        }

        _repository.DeleteMultiple(listDelete);

        return true;
    }
    #endregion

    #region Get
    public virtual TOutput? Get(int id)
    {
        return Convert(_repository.Get(id));
    }

    public virtual List<TOutput>? GetAll()
    {
        return Convert(_repository.GetAll());
    }
    #endregion

    #region Update
    public int Update(TInputUpdate? inputUpdate)
    {
        return UpdateMultiple([inputUpdate])?.FirstOrDefault() ?? 0;
    }

    public List<int>? UpdateMultiple(List<TInputUpdate>? listInputUpdate)
    {
        List<TEntity> listOriginalEntity = _repository.GetListByListId((from i in listInputUpdate ?? [] select i.Id).ToList()!)!;

        OnUpdateMultiple(listInputUpdate);

        List<TEntity> listUpdate = new List<TEntity>();
        foreach (var i in listInputUpdate ?? [])
        {
            TEntity? originalEntity = (from j in listOriginalEntity where j.Id == i.Id select j).FirstOrDefault();
            if (originalEntity == null)
                throw new Exception($"O registro Id {i.Id} não existe");

            foreach (PropertyInfo inputPropertyInfo in typeof(TInputUpdate).GetProperties())
            {
                PropertyInfo? propertyInfo = typeof(TEntity).GetProperty(inputPropertyInfo.Name);
                if (propertyInfo != null)
                    propertyInfo.SetValue(originalEntity, inputPropertyInfo.GetValue(i));
            }
            listUpdate.Add(originalEntity);
        }

        List<int> listId = _repository.UpdateMultiple(listUpdate);
        return listId;
    }

    protected virtual void OnUpdateMultiple(List<TInputUpdate>? listInputUpdate) { }
    #endregion

    #region Internal
    #region Internal
    protected TEntity? Convert(TOutput? output)
    {
        return _mapper.Map<TEntity>(output);
    }

    protected List<TEntity>? Convert(List<TOutput>? listOutput)
    {
        return _mapper.Map<List<TEntity>>(listOutput);
    }

    protected TOutput? Convert(TEntity? entity)
    {
        return _mapper.Map<TOutput>(entity);
    }

    protected List<TOutput>? Convert(List<TEntity>? lisTEntity)
    {
        return _mapper.Map<List<TOutput>>(lisTEntity);
    }
    #endregion
    #endregion
}