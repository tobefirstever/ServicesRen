using Renavi.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using System.IO;
using RenaviExterno.Application.Interfaces;
using RenaviExterno.DTO;
using RenaviExterno.Services.Interfaces;

namespace RenaviExterno.Application.Main
{
    public class SimuladorCuotasApplication : ISimuladorCuotasApplication
    {
        private readonly ISimuladorCuotasService _simuladorCuotasService;

        public SimuladorCuotasApplication(ISimuladorCuotasService simuladorCuotasService)
        {
            _simuladorCuotasService = simuladorCuotasService;
        }

        public async Task<Response<SimuladorCronogramaResponseDto>> GetCronograma(SimuladorCronogramaDto request)
        {
            return await _simuladorCuotasService.GetCronograma(request);
        }

        public async Task<Response<SimuladorCuotasComprasResponseDto>> GetList(SimuladorCuotasComprasDto request)
        {
            return await _simuladorCuotasService.GetList(request);
        }

        public async Task<Response<SimuladorCuotasConstruccionResponseDto>> GetListConstruccion(SimuladorCuotasConstruccionDto request)
        {
            return await _simuladorCuotasService.GetListConstruccion(request);
        }

        public async Task<Response<SimuladorCuotasMejoramientoResponseDto>> GetListMejoramiento(SimuladorCuotasMejoramientoDto request)
        {
            return await _simuladorCuotasService.GetListMejoramiento(request);
        }

        public async Task<Response<List<SimuladorBancosTasasResponseDto>>> GetTasas()
        {
            return await _simuladorCuotasService.GetTasas();
        }
    }
}
