using Renavi.Application.DTO.Dtos.SimuladorCuotas;
using Renavi.Application.Interfaces;
using Renavi.Domain.Entities.Entities;
using Renavi.Domain.Interfaces;
using Renavi.Transversal.Common;
using Renavi.Transversal.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renavi.Application.Main
{
    public class SimuladorCuotasApplication : ISimuladorCuotasApplication
    {
        private readonly ISimuladorCuotasDomain _simuladorCuotasDomain;

        public SimuladorCuotasApplication(ISimuladorCuotasDomain simuladorCuotasDomain)
        {
            _simuladorCuotasDomain = simuladorCuotasDomain;
        }


        public async Task<Response<IEnumerable<SimuladorCuotasDto>>> GetList()
        {
            var response = new Response<IEnumerable<SimuladorCuotasDto>> { Data = new List<SimuladorCuotasDto>() };
            IEnumerable<SimuladorCuotasEntity> gerenciaEntities = await _simuladorCuotasDomain.GetList();

            response.Data = Mapping.Map<IEnumerable<SimuladorCuotasEntity>, IEnumerable<SimuladorCuotasDto>>(gerenciaEntities);
            return response;
        }
    }
}
