using RenaviExterno.Application.Interfaces;
using RenaviExterno.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace RenaviExterno.Services.WebApi.Controllers
{
    public class ParametroController : ApiController
    {
        private readonly IParametroApplication _parametroApplication;

        public ParametroController(IParametroApplication parametroApplication)
        {
            _parametroApplication = parametroApplication;
        }

        [HttpGet()]
        [Route("api/parametro")]
        public async Task<IHttpActionResult> Buscar([FromUri] string grupoParametros)
        {
            return Ok(await _parametroApplication.Buscar(grupoParametros));
        }
    }
}
