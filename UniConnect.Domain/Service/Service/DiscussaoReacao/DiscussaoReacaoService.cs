using AutoMapper;
using UniConnect.Argument.Argument;
using UniConnect.Argument.Base;
using UniConnect.Domain.Entity;
using UniConnect.Domain.Interface.Repository.Repository;
using UniConnect.Domain.Interface.Service;

namespace UniConnect.Domain.Service;

public class DiscussaoReacaoService : BaseService<IDiscussaoReacaoRepository, DiscussaoReacao, InputCreateDiscussaoReacao, InputUpdateDiscussaoReacao, InputGenericDelete, OutputDiscussaoReacao>, IDiscussaoReacaoService
{
    public DiscussaoReacaoService(IDiscussaoReacaoRepository repository, IMapper mapper) : base(repository, mapper) { }
}