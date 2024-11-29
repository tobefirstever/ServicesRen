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
    public class EntidadesTecnicasController : ApiController
    {

        private readonly IEntidadesTecnicasApplication _entidadesTecnicasApplication;

        public EntidadesTecnicasController(IEntidadesTecnicasApplication entidadesTecnicasApplication)
        {
            _entidadesTecnicasApplication = entidadesTecnicasApplication;
        }


        [HttpPost()]
        [Route("api/entidadestecnicas")]
        public async Task<IHttpActionResult> GetList(EntidadesTecnicasDto request)
        {
            return Ok(await _entidadesTecnicasApplication.GetList(request));

        }
    }
}
