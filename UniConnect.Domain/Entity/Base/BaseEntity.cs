using UniConnect.Domain.Entity.Entity;

namespace UniConnect.Infrastructure.Entity;

public abstract class BaseEntity<TEntity>
    where TEntity : BaseEntity<TEntity>, new()
{
    public int Id { get; protected set; }
    public int UsuarioCriacaoId { get; protected set; }
    public Usuario? UsuarioCriacao { get; protected set; }
    public DateTime DataCriacao { get; protected set; }
    public int? UsuarioAlteracaoId { get; protected set; }
    public Usuario? UsuarioAlteracao { get; protected set; }
    public DateTime? DataAlteracao { get; protected set; }

    public TEntity SetCreationDate()
    {
        DataCriacao = DateTime.Now;
        return (TEntity)this;
    }

    public TEntity SetChangeDate()
    {
        DataAlteracao = DateTime.Now;
        return (TEntity)this;
    }
}