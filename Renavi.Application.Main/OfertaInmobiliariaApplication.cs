using Renavi.Application.DTO.Dtos.OfertaInmobiliaria;
using Renavi.Application.Interfaces;
using Renavi.Domain.Entities.Entities;
using Renavi.Domain.Interfaces;
using Renavi.Transversal.Common;
using Renavi.Transversal.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renavi.Application.Main
{
    public class OfertaInmobiliariaApplication : IOfertaInmobiliariaApplication
    {
        private readonly IOfertaInmobiliariaDomain _ofertaInmobiliariaDomain;

        public OfertaInmobiliariaApplication(IOfertaInmobiliariaDomain ofertaInmobiliariaDomain)
        {
            _ofertaInmobiliariaDomain = ofertaInmobiliariaDomain;
        }


        public async Task<Response<IEnumerable<OfertaInmobiliariaDto>>> GetList()
        {
            var response = new Response<IEnumerable<OfertaInmobiliariaDto>> { Data = new List<OfertaInmobiliariaDto>() };
            IEnumerable<OfertaInmobiliariaEntity> gerenciaEntities = await _ofertaInmobiliariaDomain.GetList();

            response.Data = Mapping.Map<IEnumerable<OfertaInmobiliariaEntity>, IEnumerable<OfertaInmobiliariaDto>>(gerenciaEntities);
            return response;


        }
    }
}
