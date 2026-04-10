using ClientesApp.API.Dtos.Validators;
using System.ComponentModel.DataAnnotations;

namespace ClientesApp.API.Dtos
{
    /// <summary>
    /// DTO para receber os dados da requisição de cadastro / edição de cliente.
    /// </summary>
    public class ClienteRequestDto
    {
        [MinLength(6, ErrorMessage = "O nome deve ter pelo menos {1} caracteres.")]
        [MaxLength(150, ErrorMessage = "O nome deve ter no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Nome é obrigatório.")]
        public string? Nome { get; set; }

        [CpfValidator(ErrorMessage = "CPF inválido.")]
        [Required(ErrorMessage = "CPF é obrigatório.")]
        public string? Cpf { get; set; }

        [EmailAddress(ErrorMessage = "Email inválido.")]
        [Required(ErrorMessage = "Email é obrigatório.")]
        public string? Email { get; set; }

        [RegularExpression(@"^\d{10,11}$", ErrorMessage = "Telefone deve ter 10 ou 11 dígitos.")]
        [Required(ErrorMessage = "Telefone é obrigatório.")]
        public string? Telefone { get; set; }

        [Range(1, 4, ErrorMessage = "Nível deve ser entre 1 e 4.")]
        [Required(ErrorMessage = "Nível é obrigatório.")]
        public int? Nivel { get; set; }
    }
}
