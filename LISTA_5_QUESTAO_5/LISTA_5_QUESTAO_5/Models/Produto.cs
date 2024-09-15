
using LISTA_5_QUESTAO_5.Models.Validations;
using System.ComponentModel.DataAnnotations;

namespace LISTA_5_QUESTAO_5.Models
{
    public class Produto
    {
        [Required(ErrorMessage = "A Descrição é obrigatória")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O Preço é Obrigatório")]
        [Range(0, double.MaxValue, ErrorMessage = "O Preço deve ser maior ou igual a 0 ")]
        public decimal Preco {  get; set; }

        [Required(ErrorMessage = "O Estoque é obrigatório")]
        public int Estoque { get; set; }

        [ProdutoValidation(ErrorMessage = "Codigo Inválido")]
        public string CodigoProduto {  get; set; }


    }
}
