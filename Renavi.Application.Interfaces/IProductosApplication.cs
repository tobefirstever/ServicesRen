using Renavi.Application.DTO.Dtos.Productos;
using Renavi.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renavi.Application.Interfaces
{
    public interface IProductosApplication
    {
        Task<IEnumerable<ProductosResponseDto>> GetList(ProductosDto request);

        Task<IEnumerable<ProductosWebResponseDto>> GetListWeb(ProductosWebDto request);
    }
}
