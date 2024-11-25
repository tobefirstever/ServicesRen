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
        Task<GeneralResponse> RegistrarPerfil(PerfilRequestDto perfilRequestDto);

        Task<GeneralResponse> ObtenerPerfil(int id);
    }
}
