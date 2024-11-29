using Renavi.Application.DTO.Dtos.EntidadesTecnicas;
using Renavi.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renavi.Application.Interfaces
{
    public interface IEntidadesTecnicasApplication
    {
        Task<Response<IEnumerable<EntidadesTecnicasDto>>> GetList();
        Task<EntidadesTecnicasResponseDto> ObtenerEntidadesTecnicas(List<EntidadesTecnicas> lista, EntidadesTecnicasDto request);
    }
}
