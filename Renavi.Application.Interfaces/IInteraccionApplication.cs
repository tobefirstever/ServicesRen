using Renavi.Application.DTO.Dtos.Interaccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renavi.Application.Interfaces
{
    public interface IInteraccionApplication
    {
        Task<InteraccionResponseDto> InsertInteraccion(InteraccionDto request);
    }
}
