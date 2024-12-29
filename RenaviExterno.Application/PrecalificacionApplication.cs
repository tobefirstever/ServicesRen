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
    public class PrecalificacionApplication : IPrecalificacionApplication
    {

        private readonly IPrecalificacionService _precalificacionService;

        public PrecalificacionApplication(IPrecalificacionService precalificacionservice)
        {
            _precalificacionService = precalificacionservice;
        }
        public async Task<Response<ObtenerPrecalificacionResponseDto>> GetPrecalificacion(ObtenerPrecalificacionDto request)
        {
            return await _precalificacionService.GetPrecalificacion(request);
        }

        public async Task<Response<ObtenerRespuestaResponseDto>> GetRespuesta(ObtenerRespuestaDto request)
        {
            return await _precalificacionService.GetRespuesta(request);
        }

        public async Task<Response<PrecalificacionResponseDto>> InsertarPrecalificacion(PrecalificacionDto request)
        {
            return await _precalificacionService.InsertarPrecalificacion(request);
        }
    }
}
