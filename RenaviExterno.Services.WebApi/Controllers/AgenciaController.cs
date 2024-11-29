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
    public class AgenciaController : ApiController
    {
        private readonly IAgenciaApplication _agenciaApplication;

        public AgenciaController(IAgenciaApplication agenciaApplication)
        {
            _agenciaApplication = agenciaApplication;
        }

        [HttpPost()]
        [Route("api/agencia")]
        public async Task<IHttpActionResult> GetList(AgenciaDto request)
        {
            return Ok(await _agenciaApplication.GetList(request));
        }
    }
}
