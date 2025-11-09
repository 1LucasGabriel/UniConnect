using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using UniConnect.Models;

namespace UniConnect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        static List<Aluno> alunos = new List<Aluno> { new Aluno(1, "Lucas", "lucas@gmail.com", "123456", "199")};

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(alunos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = alunos.Where(x => x.Id == id);

            if (!aluno.Any())
            {
                return NotFound("Aluno não encontrado.");
            }

            return Ok(aluno);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Aluno aluno)
        {
            var alunoExistente = alunos.Where(x => x.Id == aluno.Id || x.RA == aluno.RA);

            if (aluno == null) {
                return BadRequest("O corpo da requisição é inválido.");
            }

            if (aluno.Id == 0)
            {
                return BadRequest("O Id do aluno não pode ser 0.");
            }

            if (alunoExistente.Any())
            {
                return BadRequest("Verifique se o Id e RA enviados não estão em uso.");
            }

            alunos.Add(aluno);
            return CreatedAtAction(nameof(GetAll), new { id = aluno.Id }, aluno);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Aluno aluno)
        {
            var alunoExistente = alunos.Where(x => x.Id == id);

            if (!alunoExistente.Any())
            {
                return NotFound("Aluno não encontrado.");
            }

            if (aluno == null)
            {
                return BadRequest("O corpo da requisição é inválido.");
            }

            var alunoAtt = alunoExistente.First();

            alunoAtt.Name = aluno.Name;
            alunoAtt.Email = aluno.Email;
            alunoAtt.Password = aluno.Password;

            return Ok(new { Message = "Aluno atualizado com sucesso.", Update = alunoAtt });
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
