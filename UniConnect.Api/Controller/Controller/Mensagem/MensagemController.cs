using Microsoft.AspNetCore.Mvc;
using UniConnect.Api.Controller.Base;
using UniConnect.Argument.Argument;
using UniConnect.Argument.Base;
using UniConnect.Domain.Interface.Service;

namespace UniConnect.Api.Controller;

public class MensagemController : BaseController<IMensagemService, InputCreateMensagem, InputUpdateMensagem, InputGenericDelete, OutputMensagem>
{
    public MensagemController(IMensagemService service) : base(service) { }

    [HttpGet("GetConversaByUsuarioId/{usuarioDestinoId}")]
    public virtual ActionResult<List<OutputMensagem>> GetConversaByUsuarioId(int usuarioDestinoId)
    {
        return Ok(_service.GetConversaByUsuarioId(usuarioDestinoId));
    }
}