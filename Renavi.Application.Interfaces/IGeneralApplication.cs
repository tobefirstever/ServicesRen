using Renavi.Application.DTO.Dtos.General;
using Renavi.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renavi.Application.Interfaces
{
    public interface IGeneralApplication
    {
        Task<Response<IEnumerable<GeneralDto>>> Listar();
    }
}
