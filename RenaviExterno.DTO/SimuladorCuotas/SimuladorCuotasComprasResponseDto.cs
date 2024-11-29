using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenaviExterno.DTO
{
    public class SimuladorCuotasComprasResponseDto
    {

        public double porcentaje_cuota { get; set; }
        public double bono_bbp { get; set; }
        public double total_bbp { get; set; }
        public double monto_financiar { get; set; }
        public double tasa_anual { get; set; }
        public double cuota_mensual { get; set; }

    }
}
