using Renavi.Domain.Entities.Entities;
using Renavi.Domain.Interfaces;
using Renavi.Infrastructure.Interfaces.Repository;
using Renavi.Infrastructure.Services.Cabiel.Contracts;
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
        private readonly IExternalServiceCabiel _externalServiceCabiel;


        public UbigeoDomain(IUbigeoRepository ubigeoRepository, IExternalServiceCabiel externalServiceCabiel)
        {
            _ubigeoRepository = ubigeoRepository;
            _externalServiceCabiel = externalServiceCabiel;
        }

        public async Task<IEnumerable<UbigeoEntity>> GetList()
        {
            return await _ubigeoRepository.GetList();
        }
    }
}
