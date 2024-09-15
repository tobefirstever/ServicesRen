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
    public class OfertaInmobiliariaController : ApiController
    {
        private readonly IOfertaInmobiliariaApplication _ofertaInmobiliariaApplication;

        public OfertaInmobiliariaController(IOfertaInmobiliariaApplication ofertaInmobiliariaApplication)
        {
            _ofertaInmobiliariaApplication = ofertaInmobiliariaApplication;
        }


        [HttpGet()]
        [Route("api/ofertainmobiliaria")]
        public async Task<IHttpActionResult> GetList()
        {
            return Ok(await _ofertaInmobiliariaApplication.GetList());
        }
    }
}
