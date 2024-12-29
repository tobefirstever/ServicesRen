using Renavi.Application.DTO.Dtos.Parametro;
using Renavi.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renavi.Application.Interfaces
{
    public interface IParametroApplication
    {
        Task<IEnumerable<ParametroDto>> Buscar(string grupoParametros);
    }
}
