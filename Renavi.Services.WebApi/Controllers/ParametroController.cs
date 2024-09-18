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
    public class ParametroController : ApiController
    {
        private readonly IParametroApplication _parametroApplication;

        public ParametroController(IParametroApplication parametroApplication)
        {
            _parametroApplication = parametroApplication;
        }

        [HttpGet()]
        ///[Route("api/parametro/{idGrupo}/{codigoAbreviatura}")]
        [Route("api/parametro")]
        public async Task<IHttpActionResult> Buscar([FromUri] int idGrupo, [FromUri] string codigoAbreviatura = null)
        {
            return Ok(await _parametroApplication.Buscar(idGrupo, codigoAbreviatura));
        }


    }
}
