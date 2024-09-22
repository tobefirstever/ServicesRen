using Renavi.Application.DTO.Dtos.Parametro;
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
    public class ParametroApplication : IParametroApplication
    {
        private readonly IParametroDomain _parametroDomain;

        public ParametroApplication(IParametroDomain parametroDomain)
        {
            _parametroDomain = parametroDomain;
        }

        public async Task<Response<IEnumerable<ParametroDto>>> Buscar(string grupoParametros)
        {
            var response = new Response<IEnumerable<ParametroDto>> { Data = new List<ParametroDto>() };

            IEnumerable<ParametroEntity> parametroEntities = await _parametroDomain.ObtenerParametro(grupoParametros);

            try
            {
                response.Data = Mapping.Map<IEnumerable<ParametroEntity>, IEnumerable<ParametroDto>>(parametroEntities);
            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            

            return response;


        }
    }
}
