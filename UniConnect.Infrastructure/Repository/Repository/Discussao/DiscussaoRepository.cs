using Microsoft.EntityFrameworkCore;
using UniConnect.Domain.Entity;
using UniConnect.Domain.Interface.Repository.Repository;
using UniConnect.Infrastructure.Context;

namespace UniConnect.Infrastructure.Repository;

public class DiscussaoRepository : BaseRepository<Discussao>, IDiscussaoRepository
{
    public DiscussaoRepository(AppDbContext context) : base(context) { }

    public override List<Discussao>? GetAll()
    {
        return _dbset.Include(x => x.DiscussaoPai).AsNoTracking().ToList();
    }

    public override List<Discussao>? GetListByListId(List<int> listId)
    {
        if (listId == null || listId.Count == 0)
            return [];

        return _dbset.Where(x => listId.Contains(x.Id)).Include(x => x.DiscussaoPai).AsNoTracking().ToList();
    }

    public override Discussao? Get(int id)
    {
        return _dbset.Where(x => x.Id == id).Include(x => x.DiscussaoPai).AsNoTracking().FirstOrDefault();
    }
}