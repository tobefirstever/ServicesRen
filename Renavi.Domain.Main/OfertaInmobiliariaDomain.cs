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
    public class OfertaInmobiliariaDomain : IOfertaInmobiliariaDomain
    {
        private readonly IOfertaInmobiliariaRepository _ofertaInmobiliariaRepository;

        public OfertaInmobiliariaDomain(IOfertaInmobiliariaRepository ofertaInmobiliariaRepository)
        {
            _ofertaInmobiliariaRepository = ofertaInmobiliariaRepository;
        }


        public async Task<IEnumerable<OfertaInmobiliariaEntity>> GetList()
        {
            return await _ofertaInmobiliariaRepository.GetList();
        }
    }
}
