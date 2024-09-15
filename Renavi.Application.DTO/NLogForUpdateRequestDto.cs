using System.ComponentModel.DataAnnotations;

namespace Renavi.Application.DTO
{
    public class NLogForUpdateRequestDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Debe ingresar un valor para Hostname")]
        [MaxLength(100, ErrorMessage = "Se permite máximo 100 caracteres")]
        public string Hostname { get; set; }

        [Required(ErrorMessage = "Debe ingresar un valor para Mensaje")]
        [MaxLength(200, ErrorMessage = "Se permite máximo 200 caracteres")]
        public string Mensaje { get; set; }
    }
}
