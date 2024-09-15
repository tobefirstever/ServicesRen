using System.ComponentModel.DataAnnotations;

namespace Renavi.Application.DTO
{
    public class UsuarioLoginRequestDto
    {
        [Required(ErrorMessage = "Debe ingresar un valor para Username")]
        [MaxLength(100, ErrorMessage = "Se permite máximo 100 caracteres")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Debe ingresar un valor para Password")]
        [MaxLength(100, ErrorMessage = "Se permite máximo 100 caracteres")]
        public string Password { get; set; }
    }
}
