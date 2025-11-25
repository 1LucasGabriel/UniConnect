using AutoMapper;
using UniConnect.Argument.Argument;
using UniConnect.Argument.Base;
using UniConnect.Domain.Entity;
using UniConnect.Domain.Interface.Repository.Repository;
using UniConnect.Domain.Interface.Service;

namespace UniConnect.Domain.Service;

public class DiscussaoService : BaseService<IDiscussaoRepository, Discussao, InputCreateDiscussao, InputUpdateDiscussao, InputGenericDelete, OutputDiscussao>, IDiscussaoService
{
    public DiscussaoService(IDiscussaoRepository repository, IMapper mapper) : base(repository, mapper) { }
}