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
    public class GeneralDomain : IGeneralDomain
    {
        private readonly IGeneralRepository _generalRepository;

        public GeneralDomain(IGeneralRepository generalRepository)
        {
            _generalRepository = generalRepository;
        }

        public async Task<IEnumerable<GeneralEntity>> GetList()
        {
            return await _generalRepository.GetList();
        }
    }
}
