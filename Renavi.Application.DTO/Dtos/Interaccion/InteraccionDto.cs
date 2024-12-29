using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renavi.Application.DTO.Dtos.Interaccion
{
    public class InteraccionDto
    {
        public string Ip { get; set; }
        public string Accion { get; set; }
        public string Navegador { get; set; }
        public string UsuarioRegistro { get; set; }
        public int TipoContenido { get; set; }
        public string Metodo { get; set; }
        public string Contenido { get; set; }
    }
}
