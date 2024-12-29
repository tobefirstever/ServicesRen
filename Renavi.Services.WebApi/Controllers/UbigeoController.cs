using Renavi.Application.DTO.Dtos.Ubigeo;
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
    public class UbigeoController : ApiController
    {
        private readonly IUbigeoApplication _ubigeoApplication;

        public UbigeoController(IUbigeoApplication ubigeoApplication)
        {
            _ubigeoApplication = ubigeoApplication;
        }

        [HttpPost()]
        [Route("api/ubigeo")]
        public async Task<IHttpActionResult> GetList(UbigeoDto request)
        {
            return Ok(await _ubigeoApplication.GetList(request));
        }

        [HttpGet()]
        [Route("api/ubigeoall")]
        public async Task<IHttpActionResult> GetListAll()
        {
            return Ok(await _ubigeoApplication.GetListAll());
        }
    }
}
