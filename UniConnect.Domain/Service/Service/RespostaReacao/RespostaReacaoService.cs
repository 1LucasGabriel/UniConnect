using AutoMapper;
using UniConnect.Argument.Argument;
using UniConnect.Argument.Base;
using UniConnect.Domain.Entity;
using UniConnect.Domain.Interface.Repository.Repository;
using UniConnect.Domain.Interface.Service;

namespace UniConnect.Domain.Service;

public class RespostaReacaoService : BaseService<IRespostaReacaoRepository, RespostaReacao, InputCreateRespostaReacao, InputUpdateRespostaReacao, InputGenericDelete, OutputRespostaReacao>, IRespostaReacaoService
{
    public RespostaReacaoService(IRespostaReacaoRepository repository, IMapper mapper) : base(repository, mapper) { }
}