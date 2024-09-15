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

        [HttpGet()]
        [Route("api/precalificacion")]
        public async Task<IHttpActionResult> GetList()
        {


            return Ok(await _precalificacionApplication.GetList());
        }
    }
}
