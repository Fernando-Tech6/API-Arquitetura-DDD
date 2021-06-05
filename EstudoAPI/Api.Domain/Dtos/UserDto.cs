using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos
{
    public class UserDto
    {    /*Colocar as regras de validação*/

        [Required(ErrorMessage = "Nome é um campo obrigatório")]
        [StringLength(60, ErrorMessage = "Nome de terno máximo {1} caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Nome é um campo obrigatório")]
        [StringLength(100, ErrorMessage = "Nome de terno máximo {1} caracteres")]
        [EmailAddress(ErrorMessage = "E-mail em formato inválido")]
        public string Email { get; set; }

    }
}
