using Renavi.Application.DTO.Dtos.EntidadesTecnicas;
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
    public class EntidadesTecnicasController : ApiController
    {
        private readonly IEntidadesTecnicasApplication _entidadesTecnicasApplication;


        public EntidadesTecnicasController(IEntidadesTecnicasApplication entidadesTecnicasApplication)
        {
            _entidadesTecnicasApplication = entidadesTecnicasApplication;
        }


        [HttpPost()]
        [Route("api/entidadestecnicas")]
        public async Task<IHttpActionResult> GetList([FromBody] RequestEntidadesTecnicasDTO requestEntidadesTecnicasDTO)
        {
            return Ok(await _entidadesTecnicasApplication.ObtenerEntidadesTecnicas(requestEntidadesTecnicasDTO));
        }
    }
}

