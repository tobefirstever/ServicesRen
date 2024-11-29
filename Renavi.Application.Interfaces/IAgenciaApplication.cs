using Renavi.Application.DTO.Dtos.Agencia;
using Renavi.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renavi.Application.Interfaces
{
    public interface IAgenciaApplication
    {
        Task<List<AgenciaResponseDto>> GetList(AgenciaDto request);
    }
}
