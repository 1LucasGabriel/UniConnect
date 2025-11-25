using UniConnect.Domain.Entity;
using UniConnect.Domain.Interface.Repository.Repository;
using UniConnect.Infrastructure.Context;

namespace UniConnect.Infrastructure.Repository;

public class DiscussaoRepository : BaseRepository<Discussao>, IDiscussaoRepository
{
    public DiscussaoRepository(AppDbContext context) : base(context) { }
}