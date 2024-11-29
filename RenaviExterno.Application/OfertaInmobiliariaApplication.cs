using Renavi.Transversal.Common;
using RenaviExterno.DTO;
using RenaviExterno.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenaviExterno.Application.Interfaces
{
    public class OfertaInmobiliariaApplication : IOfertaInmobiliariaApplication
    {

        private readonly IOfertaInmobiliariaervice _ofertaService;

        public OfertaInmobiliariaApplication(IOfertaInmobiliariaervice ofertaServic)
        {
            _ofertaService = ofertaServic;
        }

        public async Task<Response<List<OfertaInmobiliariaResponseDto>>> GetList(OfertaInmobiliariaDto request)
        {
            return await _ofertaService.GetList(request);
        }

    }
}
