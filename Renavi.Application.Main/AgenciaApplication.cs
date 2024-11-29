using Renavi.Application.DTO.Dtos.Agencia;
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
    public class AgenciaApplication : IAgenciaApplication
    {
        private readonly IAgenciaDomain _agenciaDomain;

        public AgenciaApplication(IAgenciaDomain agenciaoDomain)
        {
            _agenciaDomain = agenciaoDomain;
        }


        public async Task<List<AgenciaResponseDto>> GetList(AgenciaDto request)
        {
  

            var response = new List<AgenciaResponseDto>();

           var Agencia = await _agenciaDomain.GetList();

            if (request.ubigeo!=""  && !String.IsNullOrEmpty(request.ubigeo))
            {
                Agencia = Agencia.Where(x => x.ubigeo == request.ubigeo).ToList();
            }


            response = Agencia;

            return response;
        }
    }
}
