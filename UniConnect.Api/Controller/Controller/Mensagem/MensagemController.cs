using UniConnect.Api.Controller.Base;
using UniConnect.Argument.Argument;
using UniConnect.Argument.Base;
using UniConnect.Domain.Interface.Service;

namespace UniConnect.Api.Controller;

public class MensagemController : BaseController<IMensagemService, InputCreateMensagem, InputUpdateMensagem, InputGenericDelete, OutputMensagem>
{
    public MensagemController(IMensagemService service) : base(service) { }
}