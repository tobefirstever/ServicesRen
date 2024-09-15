using Renavi.Application.DTO.Dtos.Precalificacion;
using Renavi.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renavi.Application.Interfaces
{
    public interface IPrecalificacionApplication
    {
        Task<Response<IEnumerable<PrecalificacionDto>>> GetList();
    }
}
