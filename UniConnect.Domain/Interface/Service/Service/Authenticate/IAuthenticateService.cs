using UniConnect.Argument.Argument;

namespace UniConnect.Domain.Interface.Service;

public interface IAuthenticateService
{
    OutputAuthenticate Authenticate(InputAuthenticate inputAuthenticate);
}
