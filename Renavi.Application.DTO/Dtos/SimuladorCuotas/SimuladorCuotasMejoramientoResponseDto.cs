using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renavi.Application.DTO.Dtos.SimuladorCuotas
{
    public class SimuladorCuotasMejoramientoResponseDto
    {

        public double monto_financiar { get; set; }
        public double tasa_anual { get; set; }
        public double cuota_mensual { get; set; }

    }
}
