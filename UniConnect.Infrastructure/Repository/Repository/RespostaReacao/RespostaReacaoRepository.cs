using UniConnect.Domain.Entity;
using UniConnect.Domain.Interface.Repository.Repository;
using UniConnect.Infrastructure.Context;

namespace UniConnect.Infrastructure.Repository;

public class RespostaReacaoRepository : BaseRepository<RespostaReacao>, IRespostaReacaoRepository
{
    public RespostaReacaoRepository(AppDbContext context) : base(context) { }
}