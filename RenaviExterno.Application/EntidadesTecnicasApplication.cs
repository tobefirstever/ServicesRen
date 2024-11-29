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
    public class EntidadesTecnicasApplication : IEntidadesTecnicasApplication
    {

        private readonly IEntidadesTecnicasService _ofertaService;

        public EntidadesTecnicasApplication(IEntidadesTecnicasService ofertaServic)
        {
            _ofertaService = ofertaServic;
        }

        public async Task<Response<EntidadesTecnicasResponseDto>> GetList(EntidadesTecnicasDto request)
        {
            return await _ofertaService.GetList(request);
        }

    }
}
