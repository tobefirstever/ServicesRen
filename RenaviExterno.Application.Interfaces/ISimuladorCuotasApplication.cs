
using Renavi.Transversal.Common;
using RenaviExterno.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenaviExterno.Application.Interfaces
{
    public interface ISimuladorCuotasApplication
    {
        Task<Response<SimuladorCuotasComprasResponseDto>> GetList(SimuladorCuotasComprasDto request);
        Task<Response<SimuladorCuotasMejoramientoResponseDto>> GetListMejoramiento(SimuladorCuotasMejoramientoDto request);
        Task<Response<SimuladorCuotasConstruccionResponseDto>> GetListConstruccion(SimuladorCuotasConstruccionDto request);
        Task<Response<SimuladorCronogramaResponseDto>> GetCronograma(SimuladorCronogramaDto request);
        Task<Response<List<SimuladorBancosTasasResponseDto>>> GetTasas(SimuladorBancosTasasDto request);
    }
}
