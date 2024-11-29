using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renavi.Application.DTO.Dtos.SimuladorCuotas
{
    public class SimuladorCronogramaDto
    {
        public double Valor_vivienda { get; set; }
        public double monto_financiar { get; set; }
        public double Tasa_efectiva { get; set; }
        public int plazo_meses { get; set; }
   

    }
}
