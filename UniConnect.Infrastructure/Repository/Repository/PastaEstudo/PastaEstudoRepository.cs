using UniConnect.Domain.Entity;
using UniConnect.Domain.Interface.Repository.Repository;
using UniConnect.Infrastructure.Context;

namespace UniConnect.Infrastructure.Repository;

public class PastaEstudoRepository : BaseRepository<PastaEstudo>, IPastaEstudoRepository
{
    public PastaEstudoRepository(AppDbContext context) : base(context) { }
}