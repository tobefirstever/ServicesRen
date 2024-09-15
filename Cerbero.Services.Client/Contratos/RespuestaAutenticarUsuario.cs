using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cerbero.Services.Client.Contratos
{

    public class RespuestaAutenticarUsuario
    {

        public int CodigoHttp { get; set; }

 
        public int CodigoRespuesta { get; set; }


        public string Mensaje { get; set; }

 
        public Usuario Objeto { get; set; }
    }


    public class Usuario
    {

        public string NombreUsuario { get; set; }

    
        public string Password { get; set; }


        public int TipoUsuario { get; set; }


        public string IdSistema { get; set; }


        public string Opciones { get; set; }
    
        public string NombreCompleto { get; set; }
    }
}
