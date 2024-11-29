using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renavi.Application.DTO.Dtos.SimuladorCuotas
{
    public class SimuladorCuotasMejoramientoDto
    {

        public double Valor_vivienda { get; set; }
        public double valor_obra { get; set; }
        public double Tasa_efectiva { get; set; }
        public int plazo_meses { get; set; }
        public int tipo_simulador { get; set; }

        public SimuladorCuotasMejoramientoDto() {

          Valor_vivienda = 0.00;
          valor_obra = 0.00;
          Tasa_efectiva= 0.00;
          tipo_simulador = 0;

    }


    }
}
