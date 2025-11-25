using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniConnect.Api.Controller.Base;
using UniConnect.Argument;
using UniConnect.Argument.Argument;
using UniConnect.Domain.Interface.Service;

namespace UniConnect.Api.Controller.Controller;

[ApiController]
[Route("api/[controller]")]
public class AuthenticateController : BaseController<IAuthenticateService, BaseInputCreate_0, BaseInputUpdate_0, BaseInputDelete_0, BaseOutput_0>
{
    public AuthenticateController(IAuthenticateService service) : base(service) { }

    [AllowAnonymous]
    [HttpPost("Authenticate")]
    public IActionResult Authenticate([FromBody] InputAuthenticate inputAuthenticate)
    {
        try
        {
            return Ok(_service.Authenticate(inputAuthenticate));
        }
        catch (KeyNotFoundException exception)
        {
            return NotFound(exception.Message);
        }
        catch (Exception exception)
        {
            return BadRequest(exception.Message);
        }
    }

    #region Ignore
    [NonAction]
    public override IActionResult Create(BaseInputCreate_0 inputCreate)
    {
        throw new NotImplementedException();
    }
    [NonAction]
    public override IActionResult CreateMultiple(List<BaseInputCreate_0> listInputCreate)
    {
        throw new NotImplementedException();
    }
    [NonAction]
    public override IActionResult Update(BaseInputUpdate_0 inputUpdate)
    {
        throw new NotImplementedException();
    }
    [NonAction]
    public override IActionResult UpdateMultiple(List<BaseInputUpdate_0> listInputUpdate)
    {
        throw new NotImplementedException();
    }
    [NonAction]
    public override IActionResult Delete(BaseInputDelete_0 inputDelete)
    {
        throw new NotImplementedException();
    }
    [NonAction]
    public override IActionResult DeleteMultiple(List<BaseInputDelete_0> listInputDelete)
    {
        throw new NotImplementedException();
    }
    [NonAction]
    public override ActionResult<BaseOutput_0> Get(int id)
    {
        throw new NotImplementedException();
    }
    [NonAction]
    public override ActionResult<List<BaseOutput_0>> GetAll()
    {
        throw new NotImplementedException();
    }
    #endregion
}