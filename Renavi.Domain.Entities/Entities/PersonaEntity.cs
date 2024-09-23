using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renavi.Domain.Entities.Entities
{
    public class PersonaEntity
    {
        public int IdPersona { get; set; }

        public int IdTipoDocumento { get; set; }

        public string NroDocumento { get; set; }

        public string Nombre { get; set; }

        public string ApellidoPaterno { get; set; }

        public string ApellidoMaterno { get; set; }


        public string UsuarioRegistro { get; set; }

        public DateTime FechaCreacion { get; set; }

        public string UsuarioModificacion { get; set; }

        public DateTime? FechaModificacion { get; set; }

        public virtual DireccionEntity DireccionDomicilio { get; set; }

        public virtual ContactoEntity InformacionContacto { get; set; }
    }
}
