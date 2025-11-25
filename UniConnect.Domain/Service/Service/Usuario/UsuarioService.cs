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

    protected override void OnCreateMultiple(List<InputCreateUsuario>? listInputCreate)
    {
        foreach (var i in listInputCreate)
        {
            Usuario? originalUsuario = _repository.GetByEmail(i.Email);
            if (originalUsuario != null)
                throw new Exception("Esse email ja está em uso!");
        }
    }
}