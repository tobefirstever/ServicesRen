using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renavi.Application.DTO.Dtos.Ubigeo
{
    public class UbigeoDto
    {
        public string IdUbigeo { get; set; }

        public string IdDepartamento { get; set; }

        public string IdProvincia { get; set; }

        public string IdDistrito { get; set; }

        public string Nombre { get; set; }

        public decimal Latitud { get; set; }

        public decimal Longitud { get; set; }
    }
}
