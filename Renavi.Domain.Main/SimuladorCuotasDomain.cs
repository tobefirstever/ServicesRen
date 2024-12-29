using Renavi.Application.DTO.Dtos.SimuladorCuotas;
using Renavi.Domain.Entities.Entities;
using Renavi.Domain.Interfaces;
using Renavi.Infrastructure.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renavi.Domain.Main
{
    public class SimuladorCuotasDomain : ISimuladorCuotasDomain
    {
        private readonly ISimuladorCuotasRepository _simuladorCuotasRepository;

        public SimuladorCuotasDomain(ISimuladorCuotasRepository simuladorCuotasRepository)
        {
            _simuladorCuotasRepository = simuladorCuotasRepository;
        }


        public async Task<IEnumerable<SimuladorBancosTasasResponseDto>> GetList(SimuladorBancosTasasDto request)
        {
            return await _simuladorCuotasRepository.GetList(request);
        }
    }
}
