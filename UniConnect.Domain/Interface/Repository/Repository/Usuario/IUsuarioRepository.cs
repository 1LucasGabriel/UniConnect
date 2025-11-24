using UniConnect.Domain.Entity;

namespace UniConnect.Domain.Interface.Repository.Repository;

public interface IUsuarioRepository : IBaseRepository<Usuario>
{
    Usuario? GetByEmail(string email);
}