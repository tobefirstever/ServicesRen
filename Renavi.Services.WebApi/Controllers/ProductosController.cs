using Renavi.Application.DTO.Dtos.Productos;
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

        [HttpPost()]
        [Route("api/productos")]
        public async Task<IHttpActionResult> GetList(ProductosDto request)
        {
            return Ok(await _productosApplication.GetList(request));
        }

        [HttpPost()]
        [Route("api/productosweb")]
        public async Task<IHttpActionResult> GetListWeb(ProductosWebDto request)
        {
            return Ok(await _productosApplication.GetListWeb(request));
        }
    }
}
