using Renavi.Transversal.Common;
using RenaviExterno.Application.Interfaces;
using RenaviExterno.DTO;
using RenaviExterno.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenaviExterno.Application
{
    public class InteraccionApplication : IInteraccionApplication
    {

        private readonly IInteraccionService _interaccionService;

        public InteraccionApplication(IInteraccionService interaccionService)
        {
            _interaccionService = interaccionService;
        }
        public async Task<Response<InteraccionResponseDto>> InsertInteraccion(InteraccionDto request)
        {
            return await _interaccionService.InsertInteraccion(request);
        }
    }
}
