using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renavi.Domain.Entities.Entities
{
   public class DireccionEntity
    {
        public int IdDireccion { get; set; }

        public int IdTipoVia { get; set; }

        public string Nombre { get; set; }

        public string Nro { get; set; }

        public string Mza { get; set; }

        public string Lote { get; set; }

        public string IdDepartamento { get; set; }

        public string IdProvincia { get; set; }

        public string IdDistrito { get; set; }

        public int IdTipoDomicilio { get; set; }

        public string DireccionReferencia { get; set; }

        public string CodigoPostal { get; set; }

        public decimal? Latitud { get; set; }

        public decimal? Longitud { get; set; }


        public string UsuarioRegistro { get; set; }

        public DateTime FechaCreacion { get; set; }

        public string UsuarioModificacion { get; set; }

        public DateTime? FechaModificacion { get; set; }
    }
}
