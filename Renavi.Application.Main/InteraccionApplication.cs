using Renavi.Application.DTO.Dtos.Interaccion;
using Renavi.Application.Interfaces;
using Renavi.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renavi.Application.Main
{
    public class InteraccionApplication : IInteraccionApplication
    {

        private readonly IInteraccionDomain _interaccionDomain;

        public InteraccionApplication(IInteraccionDomain interaccionDomain)
        {
            _interaccionDomain = interaccionDomain;
        }
        public async Task<InteraccionResponseDto> InsertInteraccion(InteraccionDto request)
        {
           return await _interaccionDomain.InsertInteraccion(request);
        }
    }
}
