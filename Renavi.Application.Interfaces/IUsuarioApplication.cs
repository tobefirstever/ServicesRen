using Renavi.Application.DTO.Dtos.Usuario;
using Renavi.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renavi.Application.Interfaces
{
    public interface IUsuarioApplication
    {
        Task<Response<IEnumerable<UsuarioDto>>> GetList();
        Task<UsuarioResponseDto> RegistroUsuario(UsuarioDto request);

        Task<UsuarioGeneralResponseDto> EnvioCorreoPassword(UsuarioCorreonDto request);

        Task<UsuarioGeneralResponseDto> ActualizarPassword(UsuarioACtualizarDto request);

        Task<UsuarioResponseDto> Login(UsuarioAutenticacionDto request);
    }
}
