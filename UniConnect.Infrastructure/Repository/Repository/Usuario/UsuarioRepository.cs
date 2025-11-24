using Microsoft.EntityFrameworkCore;
using UniConnect.Domain.Entity;
using UniConnect.Domain.Interface.Repository.Repository;
using UniConnect.Infrastructure.Context;
using UniConnect.Infrastructure.Encryption;

namespace UniConnect.Infrastructure.Repository;

public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
{
    public UsuarioRepository(AppDbContext context) : base(context) { }

    public override List<int> CreateMultiple(List<Usuario>? listEntity)
    {
        List<Usuario> listEncryptedUser = (from i in listEntity
                                           let encrypitedPassword = EncryptionHandler.Encrypt(i.Senha)
                                           let setValue = i.Senha = encrypitedPassword
                                           select i).ToList();

        return base.CreateMultiple(listEncryptedUser);
    }

    public Usuario? GetByEmail(string email)
    {
        Usuario? usuario = _dbset.Where(x => x.Email == email).AsNoTracking().FirstOrDefault();
        if (usuario == null)
            return null;

        usuario.Senha = EncryptionHandler.Decrypt(usuario.Senha);
        return usuario;
    }
}
