using Renavi.Application.DTO.Dtos.SimuladorCuotas;
using Renavi.Domain.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renavi.Infrastructure.Interfaces.Repository
{
    public interface ISimuladorCuotasRepository
    {
        Task<IEnumerable<SimuladorBancosTasasResponseDto>> GetList(SimuladorBancosTasasDto request);
    }
}
