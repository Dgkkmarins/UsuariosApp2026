using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ClientesApp.API.Dtos.Validators
{
    /// <summary>
    /// Classe de validação customizada para CPF
    /// </summary>
    public class CpfValidator : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value == null)
                return false;

            var cpf = value.ToString();

            if (string.IsNullOrWhiteSpace(cpf))
                return false;

            // Remove caracteres não numéricos
            cpf = Regex.Replace(cpf, "[^0-9]", "");

            // CPF deve ter 11 dígitos
            if (cpf.Length != 11)
                return false;

            // Elimina CPFs inválidos com todos números iguais
            if (new string(cpf[0], 11) == cpf)
                return false;

            // Validação do primeiro dígito
            int soma = 0;
            for (int i = 0; i < 9; i++)
                soma += (cpf[i] - '0') * (10 - i);

            int resto = soma % 11;
            int digito1 = resto < 2 ? 0 : 11 - resto;

            if (cpf[9] - '0' != digito1)
                return false;

            // Validação do segundo dígito
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += (cpf[i] - '0') * (11 - i);

            resto = soma % 11;
            int digito2 = resto < 2 ? 0 : 11 - resto;

            if (cpf[10] - '0' != digito2)
                return false;

            return true;
        }
    }
}