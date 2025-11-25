using UniConnect.Domain.Entity;
using UniConnect.Domain.Interface.Repository.Repository;
using UniConnect.Infrastructure.Context;

namespace UniConnect.Infrastructure.Repository;

public class RespostaRepository : BaseRepository<Resposta>, IRespostaRepository
{
    public RespostaRepository(AppDbContext context) : base(context) { }
}