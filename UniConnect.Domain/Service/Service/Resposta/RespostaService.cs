using AutoMapper;
using UniConnect.Argument.Argument;
using UniConnect.Argument.Base;
using UniConnect.Domain.Entity;
using UniConnect.Domain.Interface.Repository.Repository;
using UniConnect.Domain.Interface.Service;

namespace UniConnect.Domain.Service;

public class RespostaService : BaseService<IRespostaRepository, Resposta, InputCreateResposta, InputUpdateResposta, InputGenericDelete, OutputResposta>, IRespostaService
{
    public RespostaService(IRespostaRepository repository, IMapper mapper) : base(repository, mapper) { }
}