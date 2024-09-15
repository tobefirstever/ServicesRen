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
    public class UbigeoDomain : IUbigeoDomain
    {
        private readonly IUbigeoRepository _ubigeoRepository;

        public UbigeoDomain(IUbigeoRepository ubigeoRepository)
        {
            _ubigeoRepository = ubigeoRepository;
        }

        public async Task<IEnumerable<UbigeoEntity>> GetList()
        {
            return await _ubigeoRepository.GetList();
        }
    }
}
