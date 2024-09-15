using Renavi.Domain.Entities.Entities;
using Renavi.Domain.Interfaces;
using Renavi.Infrastructure.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renavi.Domain.Main
{
    public class ProductosDomain : IProductosDomain
    {
        private readonly IProductosRepository _productosRepository;

        public ProductosDomain(IProductosRepository productosRepository)
        {
            _productosRepository = productosRepository;
        }


        public async Task<IEnumerable<ProductosEntity>> GetList()
        {
            return await _productosRepository.GetList();
        }
    }
}
