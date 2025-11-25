using UniConnect.Api.Controller.Base;
using UniConnect.Argument.Argument;
using UniConnect.Argument.Base;
using UniConnect.Domain.Interface.Service;

namespace UniConnect.Api.Controller;

public class DiscussaoReacaoController : BaseController<IDiscussaoReacaoService, InputCreateDiscussaoReacao, InputUpdateDiscussaoReacao, InputGenericDelete, OutputDiscussaoReacao>
{
    public DiscussaoReacaoController(IDiscussaoReacaoService service) : base(service) { }
}