using Renavi.Application.DTO.Dtos.Agencia;
using Renavi.Domain.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renavi.Domain.Interfaces
{
    public interface IAgenciaDomain
    {
        Task<List<AgenciaResponseDto>> GetList();
    }
}
