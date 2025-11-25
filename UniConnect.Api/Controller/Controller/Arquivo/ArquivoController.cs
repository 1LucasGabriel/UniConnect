using Microsoft.AspNetCore.Mvc;
using UniConnect.Api.Controller.Base;
using UniConnect.Argument.Argument;
using UniConnect.Argument.Base;
using UniConnect.Domain.Interface.Service;

namespace UniConnect.Api.Controller;

public class ArquivoController : BaseController<IArquivoService, InputCreateArquivo, InputUpdateArquivo, InputGenericDelete, OutputArquivo>
{
    public ArquivoController(IArquivoService service) : base(service) { }

    [HttpGet("GetArquivosByPastaEstudoId/{pastaEstudoId}")]
    public virtual ActionResult<List<OutputMensagem>> GetArquivosByPastaEstudoId(int pastaEstudoId)
    {
        return Ok(_service.GetArquivosByPastaEstudoId(pastaEstudoId));
    }
}