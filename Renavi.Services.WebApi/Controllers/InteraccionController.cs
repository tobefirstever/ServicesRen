using Renavi.Application.DTO.Dtos.Interaccion;
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
    public class InteraccionController : ApiController
    {
        private readonly IInteraccionApplication _interaccionApplication;

        public InteraccionController(IInteraccionApplication interaccionApplication)
        {
            _interaccionApplication = interaccionApplication;
        }

        [HttpPost()]
        [Route("api/interaccion")]
        public async Task<IHttpActionResult> InsertInteraccion(InteraccionDto request)
        {
            return Ok(await _interaccionApplication.InsertInteraccion(request));
        }
    }
}
