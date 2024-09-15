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

        [HttpGet()]
        [Route("api/ubigeo")]
        public async Task<IHttpActionResult> GetList()
        {
            return Ok(await _ubigeoApplication.GetList());
        }
    }
}
