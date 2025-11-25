using UniConnect.Domain.Entity;
using UniConnect.Domain.Interface.Repository.Repository;
using UniConnect.Infrastructure.Context;

namespace UniConnect.Infrastructure.Repository;

public class ArquivoRepository : BaseRepository<Arquivo>, IArquivoRepository
{
    public ArquivoRepository(AppDbContext context) : base(context) { }
}