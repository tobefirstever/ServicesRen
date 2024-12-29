using Renavi.Application.DTO.Dtos.Interaccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renavi.Domain.Interfaces
{
    public interface IInteraccionDomain
    {
        Task<InteraccionResponseDto> InsertInteraccion(InteraccionDto request);
    }
}
