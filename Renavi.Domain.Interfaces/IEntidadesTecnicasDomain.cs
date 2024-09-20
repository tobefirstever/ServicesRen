using Renavi.Application.DTO.Dtos.EntidadesTecnicas;
using Renavi.Domain.Entities.Entities;
using Renavi.Transversal.Common.Cabiel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renavi.Domain.Interfaces
{
    public interface IEntidadesTecnicasDomain
    {
        Task<IEnumerable<EntidadesTecnicasEntity>> GetList();

        Task<IEnumerable<Entidad>> ObtenerEntidadesTecnicas(RequestEntidadesTecnicasDTO request);

    }
}
