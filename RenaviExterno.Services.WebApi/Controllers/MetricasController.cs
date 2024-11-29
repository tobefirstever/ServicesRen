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
    public class MetricasController : ApiController
    {
        private readonly IMetricasApplication _metricasApplication;

        public MetricasController(IMetricasApplication metrciasApplication)
        {
            _metricasApplication = metrciasApplication;
        }

        [HttpPost()]
        [Route("api/metricas")]
        public async Task<IHttpActionResult> GetList(MetricaDto request)
        {
            return Ok(await _metricasApplication.InsertMetrica(request));
        }
    }
}
