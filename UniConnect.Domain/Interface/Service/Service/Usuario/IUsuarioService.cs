
using UniConnect.Argument.Argument;
using UniConnect.Argument.Base;

namespace UniConnect.Domain.Interface.Service;

public interface IUsuarioService : IBaseService<InputCreateUsuario, InputUpdateUsuario, InputGenericDelete, OutputUsuario>
{
}
