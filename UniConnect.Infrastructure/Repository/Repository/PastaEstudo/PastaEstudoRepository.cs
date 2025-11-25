using Microsoft.EntityFrameworkCore;
using UniConnect.Domain.Entity;
using UniConnect.Domain.Interface.Repository.Repository;
using UniConnect.Infrastructure.Context;

namespace UniConnect.Infrastructure.Repository;

public class PastaEstudoRepository : BaseRepository<PastaEstudo>, IPastaEstudoRepository
{
    public PastaEstudoRepository(AppDbContext context) : base(context) { }

    public override List<PastaEstudo>? GetAll()
    {
        return _dbset.Include(x => x.PastaPai).AsNoTracking().ToList();
    }

    public override List<PastaEstudo>? GetListByListId(List<int> listId)
    {
        if (listId == null || listId.Count == 0)
            return [];

        return _dbset.Where(x => listId.Contains(x.Id)).Include(x => x.PastaPai).AsNoTracking().ToList();
    }

    public override PastaEstudo? Get(int id)
    {
        return _dbset.Where(x => x.Id == id).Include(x => x.PastaPai).AsNoTracking().FirstOrDefault();
    }
}