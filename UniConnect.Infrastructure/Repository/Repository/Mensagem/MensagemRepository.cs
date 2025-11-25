using Microsoft.EntityFrameworkCore;
using UniConnect.Argument.Cache;
using UniConnect.Domain.Entity;
using UniConnect.Domain.Interface.Repository.Repository;
using UniConnect.Infrastructure.Context;

namespace UniConnect.Infrastructure.Repository;

public class MensagemRepository : BaseRepository<Mensagem>, IMensagemRepository
{
    public MensagemRepository(AppDbContext context) : base(context) { }

    public List<Mensagem> GetConversaByUsuarioId(int usuarioDestinoId)
    {
        int loggedUserId = ApiData.Get(_apiDataGuid).UserId;
        return _dbset.Where(x => x.UsuarioDestinoId == usuarioDestinoId && x.UsuarioCriacaoId == loggedUserId).AsNoTracking().ToList();
    }
}