using UniConnect.Argument.Argument;
using UniConnect.Argument.Base;

namespace UniConnect.Domain.Interface.Service;

public interface IRespostaService : IBaseService<InputCreateResposta, InputUpdateResposta, InputGenericDelete, OutputResposta>
{
    List<OutputResposta> GetThreadByDiscussaoId(int discussaoId);
}