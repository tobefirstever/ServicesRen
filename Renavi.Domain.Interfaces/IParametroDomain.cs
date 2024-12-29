using Renavi.Domain.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renavi.Domain.Interfaces
{
    public interface IParametroDomain
    {
        Task<IEnumerable<ParametroEntity>> ObtenerParametro(string grupoParametros);
    }
}
