using Renavi.Transversal.Common.Cabiel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renavi.Infrastructure.Services.Cabiel.Contracts
{
   public interface IExternalServiceCabiel
    {
        Task<List<Entidad>> ObtenerEntidadesTecnicas(string razonSocial, string ruc, string departamento, string clasificacion);
    }
}
