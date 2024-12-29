using Renavi.Transversal.Common;
using RenaviExterno.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenaviExterno.Application.Interfaces
{
    public interface IUsuarioApplication
    {

        Task<Response<UsuarioResponseDto>> RegistroUsuario(UsuarioDto request);
        Task<Response<UsuarioGeneralResponseDto>> EnvioCorreoPassword(UsuarioCorreonDto request);

        Task<Response<UsuarioGeneralResponseDto>> ActualizarPassword(UsuarioACtualizarDto request);

        Task<Response<UsuarioResponseDto>> Login(UsuarioAutenticacionDto request);
    }
}
