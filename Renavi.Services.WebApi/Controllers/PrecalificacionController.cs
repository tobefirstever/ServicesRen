using Renavi.Application.DTO.Dtos.Precalificacion;
using Renavi.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Renavi.Services.WebApi.Controllers
{
    public class PrecalificacionController : ApiController
    {

        private readonly IPrecalificacionApplication _precalificacionApplication;

        public PrecalificacionController(IPrecalificacionApplication precalificacionApplication)
        {
            _precalificacionApplication = precalificacionApplication;
        }

        [HttpPost()]
        [Route("api/ObtenerPrecalificacion")]
        public async Task<IHttpActionResult> GetPrecalificacion(ObtenerPrecalificacionDto request)
        {


            return Ok(await _precalificacionApplication.GetPrecalificacion(request));
        }

        [HttpPost()]
        [Route("api/InsertarPrecalificacion")]
        public async Task<IHttpActionResult> InsertarPrecalificacion(PrecalificacionDto request)
        {


            return Ok(await _precalificacionApplication.InsertarPrecalificacion(request));
        }


        [HttpPost()]
        [Route("api/ObtenerRespuesta")]
        public async Task<IHttpActionResult> InsertarPrecaGetRespuestalificacion(ObtenerRespuestaDto request)
        {


            return Ok(await _precalificacionApplication.GetRespuesta(request));
        }
    }
}
