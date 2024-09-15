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
    public class SimuladorCuotasController : ApiController
    {

        private readonly ISimuladorCuotasApplication _simuladorCuotasApplication;

        public SimuladorCuotasController(ISimuladorCuotasApplication simuladorCuotasApplication)
        {
            _simuladorCuotasApplication = simuladorCuotasApplication;
        }

        [HttpGet()]
        [Route("api/simuladorcuotas")]
        public async Task<IHttpActionResult> GetList()
        {
            return Ok(await _simuladorCuotasApplication.GetList());
        }
    }
}
