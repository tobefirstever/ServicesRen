using Renavi.Application.DTO.Dtos.Productos;
using Renavi.Domain.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renavi.Domain.Interfaces
{
   public interface IProductosDomain
    {
        Task<IEnumerable<ProductosWebResponseDto>> GetList(ProductosWebDto request);
    }

}
