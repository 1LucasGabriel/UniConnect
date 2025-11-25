using UniConnect.Domain.Entity;
using UniConnect.Domain.Interface.Repository.Repository;
using UniConnect.Infrastructure.Context;

namespace UniConnect.Infrastructure.Repository;

public class MensagemRepository : BaseRepository<Mensagem>, IMensagemRepository
{
    public MensagemRepository(AppDbContext context) : base(context) { }
}