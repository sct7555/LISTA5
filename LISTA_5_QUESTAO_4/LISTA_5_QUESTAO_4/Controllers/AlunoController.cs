
using LISTA_5_QUESTAO_4.Models;
using Microsoft.AspNetCore.Mvc;

namespace LISTA_5_QUESTAO_4.Controllers
{
    [ApiController]
    [Route("API/ALUNO")]
    public class AlunoController : Controller
    {
        private static List<Aluno> listaAlunos = new List<Aluno>();

        [HttpPost]
        [Route("Adicionar")]

        public IActionResult Adicionar([FromBody] Aluno aluno)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var alunoExistente = listaAlunos.Where(a => a.CPF == aluno.CPF).FirstOrDefault();

            if (alunoExistente != null)
            {
                return BadRequest("Aluno já cadastrado");
            }
            listaAlunos.Add(aluno);
            return Ok($"Aluno {aluno.Nome} cadastrado!");
        }

        [HttpGet]
        [Route("Lista de Alunos")]

        public IActionResult MostrarLista()
        {
            return Ok(listaAlunos);
        }

        [HttpDelete]
        [Route("Remover Aluno")]

        public IActionResult Remover(string cpf)
        {
            var alunoPesquisado = listaAlunos.Where(a => a.CPF == cpf).FirstOrDefault();
            if (alunoPesquisado is null)
            {
                return NotFound("Aluno não encontrado");
            }
            listaAlunos.Remove(alunoPesquisado);
            return Ok($"Aluno {alunoPesquisado.Nome} removido!");
        }
    }
}
