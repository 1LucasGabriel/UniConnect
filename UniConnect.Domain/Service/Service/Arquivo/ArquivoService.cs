using AutoMapper;
using UniConnect.Argument.Argument;
using UniConnect.Argument.Base;
using UniConnect.Domain.Entity;
using UniConnect.Domain.Interface.Repository.Repository;
using UniConnect.Domain.Interface.Service;

namespace UniConnect.Domain.Service;

public class ArquivoService : BaseService<IArquivoRepository, Arquivo, InputCreateArquivo, InputUpdateArquivo, InputGenericDelete, OutputArquivo>, IArquivoService
{
    public ArquivoService(IArquivoRepository repository, IMapper mapper) : base(repository, mapper) { }
}