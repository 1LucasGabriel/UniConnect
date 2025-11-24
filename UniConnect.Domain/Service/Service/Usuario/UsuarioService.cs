
using AutoMapper;
using UniConnect.Argument.Argument;
using UniConnect.Argument.Base;
using UniConnect.Domain.Entity;
using UniConnect.Domain.Interface.Repository.Repository;
using UniConnect.Domain.Interface.Service;

namespace UniConnect.Domain.Service;

public class UsuarioService : BaseService<IUsuarioRepository, Usuario, InputCreateUsuario, InputUpdateUsuario, InputGenericDelete, OutputUsuario>, IUsuarioService
{
    public UsuarioService(IUsuarioRepository repository, IMapper mapper) : base(repository, mapper) { }
}
