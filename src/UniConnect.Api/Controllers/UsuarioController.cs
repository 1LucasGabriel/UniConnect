using Microsoft.AspNetCore.Mvc;
using UniConnect.Application.Services.Interfaces;
using UniConnect.Application.DTOs;
using UniConnect.Domain.Entities;

namespace UniConnect.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController: ControllerBase
    {
        private readonly IUsuarioService _service;

        public UsuarioController(IUsuarioService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Buscar()
        {
            var usuarios = await _service.Buscar();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarPorId(int id)
        {
            var usuario = await _service.BuscarPorId(id);

            if (usuario == null) 
                return NotFound();

            return Ok(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] UsuarioDTO usuario)
        {
            var user = await _service.Criar(usuario);
            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] UsuarioEntity usuarioAtt)
        {
            var usuario = await _service.Atualizar(id, usuarioAtt);

            if (usuario == null) 
                return NotFound();

            return Ok(usuario);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(int id)
        {
            bool removido = await _service.Deletar(id);
            return removido ? Ok() : NotFound();
        }
    }
}
