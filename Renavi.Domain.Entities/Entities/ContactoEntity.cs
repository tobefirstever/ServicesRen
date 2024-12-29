using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renavi.Domain.Entities.Entities
{
    public class ContactoEntity
    {
        public int IdContacto { get; set; }

        public string NroCelular { get; set; }

        public string Correo { get; set; }

        public string UsuarioRegistro { get; set; }

        public DateTime FechaCreacion { get; set; }

        public string UsuarioModificacion { get; set; }

        public DateTime? FechaModificacion { get; set; }
    }
}
