using LISTA_5_QUESTAO_5.Models;
using Microsoft.AspNetCore.Mvc;

namespace LISTA_5_QUESTAO_5.Controllers
{
    [ApiController]
    [Route("API")]
    public class ProdutoController : Controller
    {
        private static List<Produto> listaProdutos = new List<Produto>();

        [HttpPost]
        [Route("AdicionarProduto")]

        public IActionResult Adicionar([FromBody] Produto produto)
        {
            var produtoExistente = listaProdutos.Where(p => p.CodigoProduto == produto.CodigoProduto).FirstOrDefault();

            if (produtoExistente != null)
            {
                return BadRequest("Produto já cadastrado");
            }

           if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            listaProdutos.Add(produto);
            return Ok("Produto Adicionado!");
        }
        [HttpGet]
        [Route("ListaProdutos")]

        public IActionResult Mostrar()
        {
            return Ok(listaProdutos);
        }
        [HttpGet]
        [Route("PesquisarPorCodigo")]

        public IActionResult PesquisarProduto(string codigo)
        {
            var codigoPesquisado = listaProdutos.Where(p => p.CodigoProduto == codigo).FirstOrDefault();

            if (codigoPesquisado is null)
            {
                return NotFound("Produto não encontrado");
            }
            return Ok(codigoPesquisado);
        }
    }
}
