using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renavi.Application.DTO.Dtos.Usuario
{
    public class UsuarioResponseDto
    {

        public int IdUsuario { get; set; }
        public int IdPersona { get; set; }
        public string Mensaje { get; set; }

    }

    public class UsuarioAutenticacionResponseDto
    {

        public int idusuario { get; set; }
        public int idpersona { get; set; }
        public string numero_documento { get; set; }
        public string contrasena { get; set; }

    }

    public class UsuarioGeneralResponseDto
    {
        public string Mensaje { get; set; }

    }
}
