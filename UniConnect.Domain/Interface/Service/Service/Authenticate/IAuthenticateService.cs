using UniConnect.Argument;
using UniConnect.Argument.Argument;

namespace UniConnect.Domain.Interface.Service;

public interface IAuthenticateService : IBaseService<BaseInputCreate_0, BaseInputUpdate_0, BaseInputDelete_0, BaseOutput_0>
{
    OutputAuthenticate Authenticate(InputAuthenticate inputAuthenticate);
}
