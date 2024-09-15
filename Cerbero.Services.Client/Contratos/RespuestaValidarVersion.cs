using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cerbero.Services.Client.Contratos
{
    public class RespuestaValidarVersion
    {
      
        public int CodigoHttp { get; set; }
     
        public int CodigoRespuesta { get; set; }
     
        public string Mensaje { get; set; }
      
        public Sistema Objeto { get; set; }
    }

  
    public class Sistema
    {
     
        public string IdSistema { get; set; }

      
        public string Version
        { get; set; }
    }
}
