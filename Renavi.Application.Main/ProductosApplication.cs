using Renavi.Application.DTO.Dtos.Productos;
using Renavi.Application.Interfaces;
using Renavi.Domain.Entities.Entities;
using Renavi.Domain.Interfaces;
using Renavi.Transversal.Common;
using Renavi.Transversal.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renavi.Application.Main
{
    public class ProductosApplication : IProductosApplication
    {
        private readonly IProductosDomain _productosDomain;

        public ProductosApplication(IProductosDomain productosDomain)
        {
            _productosDomain = productosDomain;
        }

        public async Task<Response<IEnumerable<ProductosDto>>> GetList()
        {
            var response = new Response<IEnumerable<ProductosDto>> { Data = new List<ProductosDto>() };
            IEnumerable<ProductosEntity> gerenciaEntities = await _productosDomain.GetList();

            response.Data = Mapping.Map<IEnumerable<ProductosEntity>, IEnumerable<ProductosDto>>(gerenciaEntities);
            return response;
        }
    }
}
