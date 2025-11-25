using UniConnect.Api.Controller.Base;
using UniConnect.Argument.Argument;
using UniConnect.Argument.Base;
using UniConnect.Domain.Interface.Service;

namespace UniConnect.Api.Controller;

public class RespostaController : BaseController<IRespostaService, InputCreateResposta, InputUpdateResposta, InputGenericDelete, OutputResposta>
{
    public RespostaController(IRespostaService service) : base(service) { }
}