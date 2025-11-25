using UniConnect.Api.Controller.Base;
using UniConnect.Argument.Argument;
using UniConnect.Argument.Base;
using UniConnect.Domain.Interface.Service;

namespace UniConnect.Api.Controller;

public class RespostaReacaoController : BaseController<IRespostaReacaoService, InputCreateRespostaReacao, InputUpdateRespostaReacao, InputGenericDelete, OutputRespostaReacao>
{
    public RespostaReacaoController(IRespostaReacaoService service) : base(service) { }
}