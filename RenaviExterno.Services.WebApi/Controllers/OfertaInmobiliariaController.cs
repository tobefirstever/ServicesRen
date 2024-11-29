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
    public class OfertaInmobiliariaController : ApiController
    {

        private readonly IOfertaInmobiliariaApplication _ofertaInmobiliariaApplication;

        public OfertaInmobiliariaController(IOfertaInmobiliariaApplication ofertaInmobiliariaApplication)
        {
            _ofertaInmobiliariaApplication = ofertaInmobiliariaApplication;
        }


        [HttpPost()]
        [Route("api/ofertainmobiliaria")]
        public async Task<IHttpActionResult> GetList(OfertaInmobiliariaDto request)
        {
            return Ok(await _ofertaInmobiliariaApplication.GetList(request));

        }
    }
}
