using UniConnect.Domain.Entity;

namespace UniConnect.Domain.Interface.Repository.Repository;

public interface IArquivoRepository : IBaseRepository<Arquivo>
{
    List<Arquivo> GetArquivosByPastaEstudoId(int pastaEstudoId);
}