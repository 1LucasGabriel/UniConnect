using UniConnect.Argument.Cache;

namespace UniConnect.Domain.Entity;

public abstract class BaseEntity<TEntity>
    where TEntity : BaseEntity<TEntity>, new()
{
    public int Id { get; protected set; }
    public int UsuarioCriacaoId { get; protected set; }
    public DateTime DataCriacao { get; protected set; }
    public int? UsuarioAlteracaoId { get; protected set; }
    public DateTime? DataAlteracao { get; protected set; }

    public Usuario? UsuarioCriacao { get; protected set; }
    public Usuario? UsuarioAlteracao { get; protected set; }

    public TEntity SetDefaultValueForMigraiton()
    {
        Id = 1;
        UsuarioAlteracaoId = 1;
        DataCriacao = DateTime.Now;
        return (TEntity)this;
    }

    public TEntity SetCreationDate(Guid apiDataGuid)
    {
        DataCriacao = DateTime.Now;
        UsuarioCriacaoId = ApiData.Get(apiDataGuid)?.UserId ?? 0;
        return (TEntity)this;
    }

    public TEntity SetChangeDate(Guid apiDataGuid)
    {
        DataAlteracao = DateTime.Now;
        UsuarioAlteracaoId = ApiData.Get(apiDataGuid)?.UserId;
        return (TEntity)this;
    }
}

public class BaseEntity_0 : BaseEntity<BaseEntity_0> { }