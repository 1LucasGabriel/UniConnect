using UniConnect.Domain.Entity;

namespace UniConnect.Domain.Interface.Repository.Repository;

public interface IMensagemRepository : IBaseRepository<Mensagem>
{
    List<Mensagem> GetConversaByUsuarioId(int usuarioDestinoId);
}