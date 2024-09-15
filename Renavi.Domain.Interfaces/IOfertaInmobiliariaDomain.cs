using Renavi.Domain.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renavi.Domain.Interfaces
{
   public interface IOfertaInmobiliariaDomain
    {
        Task<IEnumerable<OfertaInmobiliariaEntity>> GetList();
    }
}
