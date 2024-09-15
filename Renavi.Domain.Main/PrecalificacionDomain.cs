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
    public class PrecalificacionDomain : IPrecalificacionDomain
    {
        private readonly IPrecalificacionRepository _precalificacionRepository;

        public PrecalificacionDomain(IPrecalificacionRepository precalificacionRepository)
        {
            _precalificacionRepository = precalificacionRepository;
        }


        public async Task<IEnumerable<PrecalificacionEntity>> GetList()
        {
            return await _precalificacionRepository.GetList();
        }
    }
}
