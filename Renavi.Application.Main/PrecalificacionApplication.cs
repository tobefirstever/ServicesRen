using Renavi.Application.DTO.Dtos.Precalificacion;
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
    public class PrecalificacionApplication : IPrecalificacionApplication
    {
        private readonly IPrecalificacionDomain _precalificacionDomain;

        public PrecalificacionApplication(IPrecalificacionDomain precalificacionDomain)
        {
            _precalificacionDomain = precalificacionDomain;
        }

        public async Task<Response<IEnumerable<PrecalificacionDto>>> GetList()
        {
            var response = new Response<IEnumerable<PrecalificacionDto>> { Data = new List<PrecalificacionDto>() };
            IEnumerable<PrecalificacionEntity> gerenciaEntities = await _precalificacionDomain.GetList();

            response.Data = Mapping.Map<IEnumerable<PrecalificacionEntity>, IEnumerable<PrecalificacionDto>>(gerenciaEntities);
            return response;
        }
    }
}
