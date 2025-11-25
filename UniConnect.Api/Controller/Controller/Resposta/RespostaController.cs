using Microsoft.AspNetCore.Mvc;
using UniConnect.Api.Controller.Base;
using UniConnect.Argument.Argument;
using UniConnect.Argument.Base;
using UniConnect.Domain.Interface.Service;

namespace UniConnect.Api.Controller;

public class RespostaController : BaseController<IRespostaService, InputCreateResposta, InputUpdateResposta, InputGenericDelete, OutputResposta>
{
    public RespostaController(IRespostaService service) : base(service) { }

    [HttpGet("GetThreadByDiscussaoId/{discussaoId}")]
    public virtual ActionResult<List<OutputResposta>> GetThreadByDiscussaoId(int discussaoId)
    {
        List<OutputResposta> data = _service.GetThreadByDiscussaoId(discussaoId);
        return Ok(data);
    }
}