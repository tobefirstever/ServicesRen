using Renavi.Transversal.Common;
using RenaviExterno.DTO;
using RenaviExterno.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenaviExterno.Application.Interfaces
{
    public class ProductosApplication : IProductosApplication
    {

        private readonly IProductoService _productoService;

        public ProductosApplication(IProductoService productoservice)
        {
            _productoService = productoservice;
        }

       public async Task<Response<List<ProductosResponseDto>>> GetList(ProductosDto request)
        {
            return await _productoService.GetList(request);
        }

        public async Task<Response<List<ProductosWebResponseDto>>> GetListWeb(ProductosWebDto request)
        {
            return await _productoService.GetListWeb(request);
        }
    }
}
