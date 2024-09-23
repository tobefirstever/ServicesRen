using Renavi.Application.DTO.Dtos.Usuario;
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
    public class UsuarioApplication : IUsuarioApplication
    {

        private readonly IUsuarioDomain _usuarioDomain;

        public UsuarioApplication(IUsuarioDomain usuarioDomain)
        {
            _usuarioDomain = usuarioDomain;
          
        }

        public async Task<Response<IEnumerable<UsuarioDto>>> GetList()
        {
            var response = new Response<IEnumerable<UsuarioDto>> { Data = new List<UsuarioDto>() };
            IEnumerable<UsuarioEntity> gerenciaEntities = await _usuarioDomain.GetList();

            response.Data = Mapping.Map<IEnumerable<UsuarioEntity>, IEnumerable<UsuarioDto>>(gerenciaEntities);
            return response;
        }

       

    }
}
