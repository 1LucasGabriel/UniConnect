using UniConnect.Api.Controller.Base;
using UniConnect.Argument.Argument;
using UniConnect.Argument.Base;
using UniConnect.Domain.Interface.Service;

namespace UniConnect.Api.Controller;

public class PastaEstudoController : BaseController<IPastaEstudoService, InputCreatePastaEstudo, InputUpdatePastaEstudo, InputGenericDelete, OutputPastaEstudo>
{
    public PastaEstudoController(IPastaEstudoService service) : base(service) { }
}