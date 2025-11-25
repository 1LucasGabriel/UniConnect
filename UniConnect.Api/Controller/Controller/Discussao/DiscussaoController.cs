using UniConnect.Api.Controller.Base;
using UniConnect.Argument.Argument;
using UniConnect.Argument.Base;
using UniConnect.Domain.Interface.Service;

namespace UniConnect.Api.Controller;

public class DiscussaoController : BaseController<IDiscussaoService, InputCreateDiscussao, InputUpdateDiscussao, InputGenericDelete, OutputDiscussao>
{
    public DiscussaoController(IDiscussaoService service) : base(service) { }
}