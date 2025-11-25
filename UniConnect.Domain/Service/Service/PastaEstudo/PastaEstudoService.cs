using AutoMapper;
using UniConnect.Argument.Argument;
using UniConnect.Argument.Base;
using UniConnect.Domain.Entity;
using UniConnect.Domain.Interface.Repository.Repository;
using UniConnect.Domain.Interface.Service;

namespace UniConnect.Domain.Service;

public class PastaEstudoService : BaseService<IPastaEstudoRepository, PastaEstudo, InputCreatePastaEstudo, InputUpdatePastaEstudo, InputGenericDelete, OutputPastaEstudo>, IPastaEstudoService
{
    public PastaEstudoService(IPastaEstudoRepository repository, IMapper mapper) : base(repository, mapper) { }
}