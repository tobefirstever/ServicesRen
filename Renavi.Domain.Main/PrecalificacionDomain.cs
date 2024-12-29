using Renavi.Application.DTO.Dtos.Precalificacion;
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


        public async Task<ObtenerPrecalificacionResponseDto> GetPrecalificacion(ObtenerPrecalificacionDto request)
        {
            return await _precalificacionRepository.GetPrecalificacion(request);
        }

        public async Task<ObtenerRespuestaResponseDto> GetRespuesta(ObtenerRespuestaDto request)
        {
            return await _precalificacionRepository.GetRespuesta(request);
        }

        public async Task<PrecalificacionResponseDto> InsertarPrecalificacion(PrecalificacionDto request)
        {
            return await _precalificacionRepository.InsertarPrecalificacion(request);
        }
    }
}
