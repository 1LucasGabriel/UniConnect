using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using UniConnect.Argument;
using UniConnect.Argument.Cache;
using UniConnect.Domain.Interface.Service;

namespace UniConnect.Api.Controller.Base;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class BaseController<TService, TInputCreate, TInputUpdate, TInputDelete, TOutput> : ControllerBase, IActionFilter
    where TService : IBaseService<TInputCreate, TInputUpdate, TInputDelete, TOutput>
    where TInputCreate : BaseInputCreate<TInputCreate>
    where TInputUpdate : BaseInputUpdate<TInputUpdate>
    where TInputDelete : BaseInputDelete<TInputDelete>
    where TOutput : BaseOutput<TOutput>
{

    protected readonly TService _service;
    protected Guid _apiDataGuid;

    public BaseController(TService service)
    {
        _service = service;
    }

    [NonAction]
    public void OnActionExecuting(ActionExecutingContext context)
    {
        string? authorizationHeader = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault();

        if (!string.IsNullOrEmpty(authorizationHeader) && authorizationHeader.StartsWith("Bearer "))
        {
            try
            {
                string? token = authorizationHeader.Substring("Bearer ".Length).Trim();
                JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

                JwtSecurityToken jwtToken = handler.ReadJwtToken(token);
                Claim subClaim = jwtToken.Claims.First(c => c.Type == JwtRegisteredClaimNames.Sub);

                int userId = int.Parse(subClaim.Value);
                _apiDataGuid = ApiData.Add(new ApiDataContent(userId));

                // Replica o guid
                _service.GetType().GetMethod("SetGuid")!.Invoke(_service, [_apiDataGuid]);
            }
            catch (Exception ex)
            {
                throw new Exception($"Token inválido - {ex.Message}");
            }
        }
    }

    [NonAction]
    public void OnActionExecuted(ActionExecutedContext context)
    {
        ApiData.Remove(_apiDataGuid);
    }

    #region Create
    [HttpPost]
    public virtual IActionResult Create(TInputCreate inputCreate)
    {
        try
        {
            return Ok(_service.Create(inputCreate));
        }
        catch (ArgumentNullException)
        {
            return BadRequest("A lista está vazia");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("Multiple")]
    public virtual IActionResult CreateMultiple(List<TInputCreate> listInputCreate)
    {
        try
        {
            return Ok(_service.CreateMultiple(listInputCreate));
        }
        catch (ArgumentNullException)
        {
            return BadRequest("A lista está vazia");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    #endregion

    #region Update
    [HttpPut]
    public virtual IActionResult Update(TInputUpdate inputUpdate)
    {
        try
        {
            return Ok(_service.Update(inputUpdate));
        }
        catch (ArgumentNullException)
        {
            return BadRequest("A lista está vazia");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("Multiple")]
    public virtual IActionResult UpdateMultiple(List<TInputUpdate> listInputUpdate)
    {
        try
        {
            return Ok(_service.UpdateMultiple(listInputUpdate));
        }
        catch (ArgumentNullException)
        {
            return BadRequest("A lista está vazia");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    #endregion

    #region Delete
    [HttpDelete]
    public virtual IActionResult Delete(TInputDelete inputDelete)
    {
        try
        {
            _service.Delete(inputDelete);
            return Ok();
        }
        catch (ArgumentNullException)
        {
            return BadRequest("A lista está vazia");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("Multiple")]
    public virtual IActionResult DeleteMultiple(List<TInputDelete> listInputDelete)
    {
        try
        {
            _service.DeleteMultiple(listInputDelete);
            return Ok();
        }
        catch (ArgumentNullException)
        {
            return BadRequest("A lista está vazia");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    #endregion

    #region Get
    [HttpGet]
    public virtual ActionResult<List<TOutput>> GetAll()
    {
        return Ok(_service.GetAll());
    }

    [HttpGet("{id}")]
    public virtual ActionResult<TOutput> Get(int id)
    {
        TOutput? data = _service.Get(id);
        if (data == null)
            return NotFound();

        return Ok(data);
    }

    #endregion
}
