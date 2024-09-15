using Renavi.Application.DTO.Dtos.Gerencia;
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
using System.Transactions;

namespace Renavi.Application.Main
{
    public class GerenciaApplication : IGerenciaApplication
    {

        private readonly IGerenciaDomain _gerenciaDomain;

        public GerenciaApplication(IGerenciaDomain gerenciaDomain)
        {

            _gerenciaDomain = gerenciaDomain;
        }



        public async Task<Response<IEnumerable<GerenciaDto>>> GetList()
        {
            var response = new Response<IEnumerable<GerenciaDto>> { Data = new List<GerenciaDto>() };
            IEnumerable<GerenciaEntity> gerenciaEntities = await _gerenciaDomain.GetList();

            response.Data = Mapping.Map<IEnumerable<GerenciaEntity>, IEnumerable<GerenciaDto>>(gerenciaEntities);
            return response;
        }
    }
}
