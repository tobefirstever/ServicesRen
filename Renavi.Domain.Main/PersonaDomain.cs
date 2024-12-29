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
    public class PersonaDomain : IPersonaDomain
    {
        private readonly IPersonaRepository _personaRepository;

        public PersonaDomain(IPersonaRepository personaRepository)
        {
            _personaRepository = personaRepository;
        }

        public async Task<int> RegistrarPersona(PersonaEntity request, string usuarioCreacion)
        {
            request.UsuarioRegistro = usuarioCreacion;

            return await _personaRepository.RegistrarPersona(request);

        }

        public async Task<PersonaEntity> ObtenerPersona(int id)
        {
            return await _personaRepository.ObtenerPersona(id);
        }

        public async Task<string> ActualizarPersona(EditarPerfilModel personaEntity)
        {
            return await _personaRepository.ActualizarPersona(personaEntity);
        }
    }
}
