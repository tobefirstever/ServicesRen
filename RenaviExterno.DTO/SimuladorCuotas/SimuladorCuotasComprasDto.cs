using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenaviExterno.DTO
{
    public class SimuladorCuotasComprasDto
    {

        public double Valor_vivienda { get; set; }
        public double Cuota_inicial { get; set; }
        public bool Flag_apoyoHabitacional { get; set; }
        public bool Flag_sostenible { get; set; }
        public bool Flag_bppintegrador { get; set; }
        public double Tasa_efectiva { get; set; }
        public int plazo_meses { get; set; }
        public int tipo_simulador { get; set; }

        public SimuladorCuotasComprasDto() {

          Valor_vivienda = 0.00;
          Cuota_inicial = 0.00;
          Flag_apoyoHabitacional = false;
          Flag_sostenible = false;
          Flag_bppintegrador = false;
          Tasa_efectiva= 0.00;
           tipo_simulador = 0;

    }


    }
}
