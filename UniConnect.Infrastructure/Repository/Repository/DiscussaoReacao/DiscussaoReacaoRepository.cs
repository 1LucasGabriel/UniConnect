using UniConnect.Domain.Entity;
using UniConnect.Domain.Interface.Repository.Repository;
using UniConnect.Infrastructure.Context;

namespace UniConnect.Infrastructure.Repository;

public class DiscussaoReacaoRepository : BaseRepository<DiscussaoReacao>, IDiscussaoReacaoRepository
{
    public DiscussaoReacaoRepository(AppDbContext context) : base(context) { }
}