using LISTA_5_QUESTAO_4.Models.Validations;
using System.ComponentModel.DataAnnotations;

namespace LISTA_5_QUESTAO_4.Models
{
    public class Aluno
    {
        public string Nome { get; set; }

        [AlunoValidation(ErrorMessage = "RA Inválido")]
        public string RA {  get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Ativo { get; set; }
    }
}
