using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniConnect.Argument.Argument;
using UniConnect.Domain.Interface.Service;

namespace UniConnect.Api.Controller.Controller;

[ApiController]
[Route("api/[controller]")]
public class AuthenticateController : ControllerBase
{
    private readonly IAuthenticateService _authenticateService;

    public AuthenticateController(IAuthenticateService authenticateService)
    {
        _authenticateService = authenticateService;
    }

    [AllowAnonymous]
    [HttpPost("Authenticate")]
    public IActionResult Authenticate([FromBody] InputAuthenticate inputAuthenticate)
    {
        try
        {
            return Ok(_authenticateService.Authenticate(inputAuthenticate));
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