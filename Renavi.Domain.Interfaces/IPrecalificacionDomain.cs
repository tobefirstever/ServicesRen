using Renavi.Application.DTO.Dtos.Precalificacion;
using Renavi.Domain.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renavi.Domain.Interfaces
{
  public  interface IPrecalificacionDomain
    {
 

        Task<PrecalificacionResponseDto> InsertarPrecalificacion(PrecalificacionDto request);

        Task<ObtenerPrecalificacionResponseDto> GetPrecalificacion(ObtenerPrecalificacionDto request);
        Task<ObtenerRespuestaResponseDto> GetRespuesta(ObtenerRespuestaDto request);
    }
}
