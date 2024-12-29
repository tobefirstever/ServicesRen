using Renavi.Application.DTO.Dtos.Usuario;
using Renavi.Domain.Entities.Entities;
using Renavi.Domain.Interfaces;
using Renavi.Infrastructure.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renavi.Domain.Main
{
    public class UsuarioDomain : IUsuarioDomain
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioDomain(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<UsuarioGeneralResponseDto> ActualizarPassword(UsuarioACtualizarDto request)
        {
            return await _usuarioRepository.ActualizarPassword(request);
        }

        public async Task<UsuarioGeneralResponseDto> EnvioCorreoPassword(UsuarioCorreonDto request)
        {
            return await _usuarioRepository.EnvioCorreoPassword(request);
        }

        public async Task<IEnumerable<UsuarioEntity>> GetList()
        {
            return await _usuarioRepository.GetList();
        }

        public async Task<UsuarioAutenticacionResponseDto> Login(UsuarioAutenticacionDto request)
        {
            return await _usuarioRepository.Login(request);
        }

        public async Task<UsuarioResponseDto> RegistroUsuario(UsuarioDto request)
        {
            return await _usuarioRepository.RegistroUsuario(request);
        }
    }
}
