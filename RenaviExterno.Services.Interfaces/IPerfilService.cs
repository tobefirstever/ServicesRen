using Renavi.Transversal.Common;
using RenaviExterno.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenaviExterno.Services.Interfaces
{
    public interface IPerfilService
    {

        Task<Response<bool>> RegistrarPerfil(PerfilRequestDto perfilRequestDto);

        Task<Response<PersonaDto>> ObtenerPerfil(int id);

        Task<Response<string>> ActualizarPersona(EditarPerfilModel personaEntity);
    }
}
