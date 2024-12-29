using Renavi.Application.DTO.Dtos.Usuario;
using Renavi.Domain.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renavi.Infrastructure.Interfaces.Repository
{
    public interface IPersonaRepository
    {
        Task<int> RegistrarPersona(PersonaEntity personaEntity);

        Task<string> ActualizarPersona(EditarPerfilModel personaEntity);

        Task<PersonaEntity> ObtenerPersona(int id);
    }
}
