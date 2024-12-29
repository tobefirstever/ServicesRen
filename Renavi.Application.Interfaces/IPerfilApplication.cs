using Renavi.Application.DTO.Dtos.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renavi.Application.Interfaces
{
    public interface IPerfilApplication
    {
        Task<bool> RegistrarPerfil(PerfilRequestDto perfilRequestDto);

        Task<PersonaDto> ObtenerPerfil(int id);

        Task<string> ActualizarPersona(EditarPerfilModel personaEntity);
    }
}
