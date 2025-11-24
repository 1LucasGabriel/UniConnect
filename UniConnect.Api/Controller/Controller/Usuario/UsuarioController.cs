using UniConnect.Api.Controller.Base;
using UniConnect.Argument.Argument;
using UniConnect.Argument.Base;
using UniConnect.Domain.Interface.Service;

namespace UniConnect.Api.Controller;

public class UsuarioController : BaseController<IUsuarioService, InputCreateUsuario, InputUpdateUsuario, InputGenericDelete, OutputUsuario>
{
    public UsuarioController(IUsuarioService service) : base(service) { }
}
