using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renavi.Application.DTO.Dtos.Precalificacion
{
    public class ObtenerRespuestaDto
    {
        public int Tipo { get; set; }
        public int ingresonetofamiliarmensual { get; set; }
        public int situacionvivienda { get; set; }
        public bool flagviviendainscritaregistrospublicos { get; set; }
        public bool flagapoyodelestadoparaviviendaantes { get; set; }
    }
}
