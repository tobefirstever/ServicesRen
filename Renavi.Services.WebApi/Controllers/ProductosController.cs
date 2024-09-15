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
    public class ProductosController : ApiController
    {

        private readonly IProductosApplication _productosApplication;

        public ProductosController(IProductosApplication productosApplication)
        {
            _productosApplication = productosApplication;
        }

        [HttpGet()]
        [Route("api/precalificacion")]
        public async Task<IHttpActionResult> GetList()
        {
            return Ok(await _productosApplication.GetList());
        }
    }
}
