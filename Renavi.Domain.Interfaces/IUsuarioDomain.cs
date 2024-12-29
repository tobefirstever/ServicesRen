using Renavi.Application.DTO.Dtos.Usuario;
using Renavi.Domain.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renavi.Domain.Interfaces
{
   public interface IUsuarioDomain
    {
        Task<IEnumerable<UsuarioEntity>> GetList();
        Task<UsuarioResponseDto> RegistroUsuario(UsuarioDto request);

        Task<UsuarioGeneralResponseDto> EnvioCorreoPassword(UsuarioCorreonDto request);

        Task<UsuarioGeneralResponseDto> ActualizarPassword(UsuarioACtualizarDto request);

        Task<UsuarioAutenticacionResponseDto> Login(UsuarioAutenticacionDto request);
    }
}
