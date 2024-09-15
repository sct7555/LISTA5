using System.ComponentModel.DataAnnotations;
using System;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Text.RegularExpressions;

namespace LISTA_5_QUESTAO_5.Models.Validations
{
    public class ProdutoValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            if (value == null)
            {
                return ValidationResult.Success;
            }
            var codigoProduto = value.ToString();
            var hifen = codigoProduto[3];
            string numerosCodigo = codigoProduto.Substring(codigoProduto.Length - 4);
            string letrasCodigo = codigoProduto.Substring(0, 3);

            if (codigoProduto.Length != 8)
            {
                return new ValidationResult("O código do produto deve ter exatamente 8 caracteres.");
            }

            if (!IsAllUpperCase(letrasCodigo))
            {
                return new ValidationResult("O código deve ter as três primeiras letras maiúsculas, exemplo: 'AAA-1234'");
            }

            if (hifen != '-')
            {
                return new ValidationResult("O código deve ter hífen ('-') entre as letras e os números, exemplo: 'AAA-1234'");
            }

            if (!IsDigitsOnly(numerosCodigo))
            {
                return new ValidationResult("Os quatro últimos caracteres devem ser números.");
            }

            return ValidationResult.Success;
        }
        private bool IsDigitsOnly(string value)
        {
            foreach (char c in value)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }
        private bool IsAllUpperCase(string input)
        {
            foreach (char c in input)
            {
                if (!char.IsUpper(c))
                {
                    return false;
                }
            }
            return true;
        }

    }
}
