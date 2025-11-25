using UniConnect.Domain.Entity;

namespace UniConnect.Domain.Interface.Repository;

public interface IBaseRepository<TEntity>
        where TEntity : BaseEntity<TEntity>, new()
{
    List<TEntity>? GetAll();
    TEntity? Get(int id);
    List<TEntity>? GetListByListId(List<int> listId);
    int Create(TEntity? dto);
    List<int> CreateMultiple(List<TEntity>? lisTEntity);
    int Update(TEntity? dto);
    List<int> UpdateMultiple(List<TEntity>? lisTEntity);
    void Delete(TEntity? dto);
    void DeleteMultiple(List<TEntity>? dto);
}

public interface IBaseRepository_0 : IBaseRepository<BaseEntity_0> { }