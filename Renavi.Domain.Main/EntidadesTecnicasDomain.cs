using Renavi.Domain.Entities.Entities;
using Renavi.Domain.Interfaces;
using Renavi.Infrastructure.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renavi.Domain.Main
{
    public class EntidadesTecnicasDomain : IEntidadesTecnicasDomain
    {
        private readonly IEntidadesTecnicasRepository _entidadesTecnicasRepository;

        public EntidadesTecnicasDomain(IEntidadesTecnicasRepository entidadesTecnicasRepository)
        {
            _entidadesTecnicasRepository = entidadesTecnicasRepository;
        }

        public async Task<IEnumerable<EntidadesTecnicasEntity>> GetList()
        {
            return await _entidadesTecnicasRepository.GetList();
        }
    }
}
