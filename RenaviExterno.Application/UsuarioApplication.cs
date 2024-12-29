using Renavi.Transversal.Common;
using RenaviExterno.Application.Interfaces;
using RenaviExterno.DTO;
using RenaviExterno.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenaviExterno.Application
{
    public class UsuarioApplication : IUsuarioApplication
    {
        private readonly IUsuarioService _usuarioapplication;

        public UsuarioApplication(IUsuarioService usuarioapplication)
        {
            _usuarioapplication = usuarioapplication;
        }

        public async Task<Response<UsuarioGeneralResponseDto>> ActualizarPassword(UsuarioACtualizarDto request)
        {
            return await _usuarioapplication.ActualizarPassword(request);
        }

        public async Task<Response<UsuarioGeneralResponseDto>> EnvioCorreoPassword(UsuarioCorreonDto request)
        {
            return await _usuarioapplication.EnvioCorreoPassword(request);
        }

        public async Task<Response<UsuarioResponseDto>> Login(UsuarioAutenticacionDto request)
        {
            return await _usuarioapplication.Login(request);
        }

        public async Task<Response<UsuarioResponseDto>> RegistroUsuario(UsuarioDto request)
        {
            return await _usuarioapplication.RegistroUsuario(request);
        }
    }
}
