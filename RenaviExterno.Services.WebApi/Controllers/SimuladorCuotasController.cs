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
    public class SimuladorCuotasController : ApiController
    {
        private readonly ISimuladorCuotasApplication _simuladorCuotasApplication;

        public SimuladorCuotasController(ISimuladorCuotasApplication simuladorCuotasApplication)
        {
            _simuladorCuotasApplication = simuladorCuotasApplication;
        }

        [HttpPost()]
        [Route("api/simuladorcuotascompras")]
        public async Task<IHttpActionResult> SimuladorCompras(SimuladorCuotasComprasDto request)
        {
            return Ok(await _simuladorCuotasApplication.GetList(request));
        }


        [HttpPost()]
        [Route("api/simuladorcuotasmejoramiento")]
        public async Task<IHttpActionResult> SimuladorMejoramiento(SimuladorCuotasMejoramientoDto request)
        {
            return Ok(await _simuladorCuotasApplication.GetListMejoramiento(request));
        }

        [HttpPost()]
        [Route("api/simuladorcuotasconstruccion")]
        public async Task<IHttpActionResult> SimuladorConstruccion(SimuladorCuotasConstruccionDto request)
        {
            return Ok(await _simuladorCuotasApplication.GetListConstruccion(request));
        }

        [HttpPost()]
        [Route("api/Cronograma")]
        public async Task<IHttpActionResult> GetCronograma(SimuladorCronogramaDto request)
        {
            return Ok(await _simuladorCuotasApplication.GetCronograma(request));
        }

        [HttpPost()]
        [Route("api/BancosTasas")]
        public async Task<IHttpActionResult> GetTasas()
        {
            return Ok(await _simuladorCuotasApplication.GetTasas());
        }
    }
}
