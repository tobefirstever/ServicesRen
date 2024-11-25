using Renavi.Application.DTO.Dtos.General;
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
    public class GeneralApplication : IGeneralApplication
    {


        private readonly IGeneralDomain _generalDomain;
     

        public GeneralApplication(IGeneralDomain generalDomain)
        {
            _generalDomain = generalDomain;
       
        }

        public async Task<Response<IEnumerable<GeneralDto>>> Listar()
        {
            var respuesta = new Response<IEnumerable<GeneralDto>> { Data = new List<GeneralDto>() };
           
                IEnumerable<GeneralEntity> general = await _generalDomain.GetList();
                respuesta.Data = Mapping.Map<IEnumerable<GeneralEntity>, IEnumerable<GeneralDto>>(general);
            
           
                respuesta.IsSuccess = false;
                respuesta.Message = Mensajes.ErrorEnconsulta;
               
            
            return respuesta;
        }
    }
}
