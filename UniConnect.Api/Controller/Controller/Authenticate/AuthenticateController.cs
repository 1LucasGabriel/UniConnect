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
}