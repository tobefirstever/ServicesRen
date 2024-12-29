using Renavi.Transversal.Common;
using RenaviExterno.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenaviExterno.Services.Interfaces
{
    public interface IPrecalificacionService
    {
        Task<Response<PrecalificacionResponseDto>> InsertarPrecalificacion(PrecalificacionDto request);

        Task<Response<ObtenerPrecalificacionResponseDto>> GetPrecalificacion(ObtenerPrecalificacionDto request);
        Task<Response<ObtenerRespuestaResponseDto>> GetRespuesta(ObtenerRespuestaDto request);
    }
}
