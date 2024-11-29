using Renavi.Application.DTO.Dtos.SimuladorCuotas;
using Renavi.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renavi.Application.Interfaces
{
    public interface ISimuladorCuotasApplication
    {
        Task<SimuladorCuotasComprasResponseDto> GetList(SimuladorCuotasComprasDto request);
        Task<SimuladorCuotasMejoramientoResponseDto> GetListMejoramiento(SimuladorCuotasMejoramientoDto request);
        Task<SimuladorCuotasConstruccionResponseDto> GetListConstruccion(SimuladorCuotasConstruccionDto request);
        Task<SimuladorCronogramaResponseDto> GetCronograma(SimuladorCronogramaDto request);
        Task<List<SimuladorBancosTasasResponseDto>> GetTasas();
    }
}
