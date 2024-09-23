using Renavi.Domain.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renavi.Domain.Interfaces
{
  public  interface IPersonaDomain
    {
        Task<int> RegistrarPersona(PersonaEntity request, string usuarioCreacion);

        Task<PersonaEntity> ObtenerPersona(int id);
    }
}
