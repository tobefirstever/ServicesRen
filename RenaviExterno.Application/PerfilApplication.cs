using Renavi.Transversal.Common;
using RenaviExterno.Application.Interfaces;
using RenaviExterno.DTO;
using RenaviExterno.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenaviExterno.Application.Interfaces
{
    public class PerfilApplication : IPerfilApplication
    {

        private readonly IPerfilService _perfilService;

        public PerfilApplication(IPerfilService perfilservice)
        {
            _perfilService = perfilservice;
        }

        public async Task<Response<string>> ActualizarPersona(EditarPerfilModel personaEntity)
        {
            return await _perfilService.ActualizarPersona(personaEntity);
        }

        public async Task<Response<PersonaDto>> ObtenerPerfil(int id)
        {
            return await _perfilService.ObtenerPerfil(id);
        }

        public async Task<Response<bool>> RegistrarPerfil(PerfilRequestDto perfilRequestDto)
        {
            return await _perfilService.RegistrarPerfil(perfilRequestDto);
        }
    }
}
