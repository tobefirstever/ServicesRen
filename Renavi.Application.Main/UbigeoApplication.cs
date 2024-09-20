using Renavi.Application.DTO.Dtos.Ubigeo;
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
    public class UbigeoApplication : IUbigeoApplication
    {
        private readonly IUbigeoDomain _ubigeoDomain;
      

        public UbigeoApplication(IUbigeoDomain ubigeoDomain)
        {
            _ubigeoDomain = ubigeoDomain;
        }


        public async Task<Response<IEnumerable<UbigeoDto>>> GetList()
        {
            var response = new Response<IEnumerable<UbigeoDto>> { Data = new List<UbigeoDto>() };
            IEnumerable<UbigeoEntity> gerenciaEntities = await _ubigeoDomain.GetList();

            response.Data = Mapping.Map<IEnumerable<UbigeoEntity>, IEnumerable<UbigeoDto>>(gerenciaEntities);
            return response;
        }
    }
}
