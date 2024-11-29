using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renavi.Application.DTO.Dtos.Agencia
{
    public class AgenciaResponseDto
    {

        public string nombre_agencia { get; set; }
        public string ubigeo { get; set; }

        public string direccion { get; set; }

        public string coordenadas { get; set; }
        public bool cac { get; set; }
    }
}
