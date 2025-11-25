using Microsoft.EntityFrameworkCore;
using UniConnect.Domain.Entity;
using UniConnect.Domain.Interface.Repository;
using UniConnect.Infrastructure.Context;

namespace UniConnect.Infrastructure.Repository;

public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : BaseEntity<TEntity>, new()
{
    protected readonly AppDbContext _context;
    protected readonly DbSet<TEntity> _dbset;
    protected Guid _apiDataGuid;

    public BaseRepository(AppDbContext context)
    {
        _context = context;
        _dbset = _context.Set<TEntity>();
    }

    #region Create
    public virtual int Create(TEntity? entity)
    {
        return CreateMultiple([entity]).First();
    }

    public virtual List<int> CreateMultiple(List<TEntity>? listEntity)
    {
        if (listEntity == null || listEntity.Count == 0)
            return [];

        _context.AddRange(from i in listEntity select i.SetCreationDate(_apiDataGuid));
        _context.SaveChanges();

        return (from i in listEntity select i.Id).ToList();
    }
    #endregion

    #region Get
    public virtual List<TEntity>? GetAll()
    {
        return _dbset.AsNoTracking().ToList();
    }

    public virtual List<TEntity>? GetListByListId(List<int> listId)
    {
        if (listId == null || listId.Count == 0)
            return [];

        return _dbset.Where(x => listId.Contains(x.Id)).AsNoTracking().ToList();
    }

    public virtual TEntity? Get(int id)
    {
        return _dbset.Where(x => x.Id == id).AsNoTracking().FirstOrDefault();
    }
    #endregion

    #region Update
    public virtual int Update(TEntity? updateEntity)
    {
        return UpdateMultiple([updateEntity]).FirstOrDefault();
    }

    public List<int> UpdateMultiple(List<TEntity>? listUpdateEntity)
    {
        if (listUpdateEntity == null || listUpdateEntity.Count == 0)
            return [];

        _context.UpdateRange(from i in listUpdateEntity select i.SetChangeDate(_apiDataGuid));
        _context.SaveChanges();

        return (from i in listUpdateEntity select i.Id).ToList();
    }
    #endregion

    #region Delete
    public virtual void Delete(TEntity? Entity)
    {
        DeleteMultiple([Entity]);
    }

    public void DeleteMultiple(List<TEntity>? listEntity)
    {
        if (listEntity == null || listEntity.Count == 0)
            return;

        _context.RemoveRange(listEntity);
        _context.SaveChanges();
    }
    #endregion

    #region Internal
    public void SetGuid(Guid apiDataGuid)
    {
        _apiDataGuid = apiDataGuid;
    }
    #endregion
}