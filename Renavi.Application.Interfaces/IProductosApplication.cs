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
        Task<Response<IEnumerable<ProductosDto>>> GetList();
    }
}
