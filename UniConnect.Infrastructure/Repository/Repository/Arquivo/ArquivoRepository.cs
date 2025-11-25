using Microsoft.EntityFrameworkCore;
using UniConnect.Domain.Entity;
using UniConnect.Domain.Interface.Repository.Repository;
using UniConnect.Infrastructure.Context;

namespace UniConnect.Infrastructure.Repository;

public class ArquivoRepository : BaseRepository<Arquivo>, IArquivoRepository
{
    public ArquivoRepository(AppDbContext context) : base(context) { }

    public List<Arquivo> GetArquivosByPastaEstudoId(int pastaEstudoId)
    {
        return _dbset.Where(x => x.PastaEstudoId == pastaEstudoId).AsNoTracking().ToList();
    }
}