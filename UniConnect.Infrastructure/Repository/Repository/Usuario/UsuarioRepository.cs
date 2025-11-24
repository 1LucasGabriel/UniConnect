
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UniConnect.Domain.Entity.Entity;
using UniConnect.Domain.Interface.Repository.Repository;
using UniConnect.Infrastructure.Context;

namespace UniConnect.Infrastructure.Repository;

public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
{
    public UsuarioRepository(AppDbContext context) : base(context) { }

    public Usuario? GetByEmail(string email)
    {
        return _dbset.Where(x => x.Email == email).AsNoTracking().FirstOrDefault();
    }
}
