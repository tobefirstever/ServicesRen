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


        public async Task<ObtenerPrecalificacionResponseDto> GetPrecalificacion(ObtenerPrecalificacionDto request)
        {
            return await _precalificacionDomain.GetPrecalificacion(request);
        }

        public async Task<ObtenerRespuestaResponseDto> GetRespuesta(ObtenerRespuestaDto request)
        {
            return await _precalificacionDomain.GetRespuesta(request);
        }

        public async Task<PrecalificacionResponseDto> InsertarPrecalificacion(PrecalificacionDto request)
        {
            return await _precalificacionDomain.InsertarPrecalificacion(request);
        }
    }
}
