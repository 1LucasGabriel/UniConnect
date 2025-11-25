using AutoMapper;
using UniConnect.Argument.Argument;
using UniConnect.Argument.Base;
using UniConnect.Domain.Entity;
using UniConnect.Domain.Interface.Repository.Repository;
using UniConnect.Domain.Interface.Service;

namespace UniConnect.Domain.Service;

public class MensagemService : BaseService<IMensagemRepository, Mensagem, InputCreateMensagem, InputUpdateMensagem, InputGenericDelete, OutputMensagem>, IMensagemService
{
    public MensagemService(IMensagemRepository repository, IMapper mapper) : base(repository, mapper) { }
}