using System.ComponentModel.DataAnnotations;
using System;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Text.RegularExpressions;

namespace LISTA_5_QUESTAO_4.Models.Validations
{
    public class AlunoValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            if (value == null)
            {
                return ValidationResult.Success;
            }
            string codigoAluno = value.ToString();
            string letrasRA = codigoAluno.Substring(0, 2);
            string numerosRA = codigoAluno.Substring(codigoAluno.Length - 6);

            if (codigoAluno.Length != 8)
            {
                return new ValidationResult("O RA deve ter exatamente 8 caracteres.");
            }

            if (!IsDigitsOnly(numerosRA))
            {
                return new ValidationResult("Os ultimos 6 caracteres devem ser digitos, exemplo: 'RA046930'");
            }
            if (letrasRA != "RA")
            {
                return new ValidationResult("Os 2 primeiros caracteres devem ser as letras RA em maiúsculo, exemplo 'RA046930'");
            }
            if (IsRepeatingDigits(codigoAluno))
            {
                return new ValidationResult("Os dígitos não podem repetir, exemplo 'RA046930'");
            }

            if (!HasAtLeastTwoDigitsSame(numerosRA))
            {
                return new ValidationResult("Os 6 dígitos devem ser distintos, exemplo: 'RA046930'");
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
        private bool IsRepeatingDigits(string value)
        {
            string numeros = value.Substring(2); // Pega apenas a parte numérica
            char firstChar = numeros[0]; // Compara apenas os dígitos
            for (int i = 1; i < numeros.Length; i++)
            {
                if (numeros[i] != firstChar)
                {
                    return false;
                }
            }
            return true;
        }
        private bool HasAtLeastTwoDigitsSame(string value)
        {

            var digitCounts = new Dictionary<char, int>();
            foreach (char c in value)
            {
                if (char.IsDigit(c))
                {
                    if (digitCounts.ContainsKey(c))
                    {
                        digitCounts[c]++;
                    }
                    else
                    {
                        digitCounts[c] = 1;
                    }
                    if (digitCounts[c] >= 2)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}