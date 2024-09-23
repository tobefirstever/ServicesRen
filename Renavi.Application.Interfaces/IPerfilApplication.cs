using Renavi.Application.DTO.Dtos.Usuario;
using Renavi.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renavi.Application.Interfaces
{
    public interface IPerfilApplication
    {
        Task<Response<bool>> RegistrarPerfil(PerfilRequestDto perfilRequestDto);

        Task<Response<PersonaDto>> ObtenerPerfil(int id);
    }
}
