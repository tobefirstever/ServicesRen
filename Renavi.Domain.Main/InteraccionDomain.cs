using Renavi.Application.DTO.Dtos.Interaccion;
using Renavi.Domain.Interfaces;
using Renavi.Infrastructure.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renavi.Domain.Main
{
    public class InteraccionDomain : IInteraccionDomain
    {

        private readonly IInteraccionRepository _interaccionRepository;

        public InteraccionDomain(IInteraccionRepository interaccionRepository)
        {
            _interaccionRepository = interaccionRepository;
        }
        public async Task<InteraccionResponseDto> InsertInteraccion(InteraccionDto request)
        {
            return await _interaccionRepository.InsertInteraccion(request);
        }
    }
}
