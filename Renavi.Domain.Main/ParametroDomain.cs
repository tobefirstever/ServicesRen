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
    public class ParametroDomain : IParametroDomain
    {
        private readonly IParametroRepository _parametroRepository;

        public ParametroDomain(IParametroRepository parametroRepository)
        {
            _parametroRepository = parametroRepository;
        }

        public async Task<IEnumerable<ParametroEntity>> ObtenerParametro(int idGrupo, string codigoAbreviatura)
        {
            return await _parametroRepository.ObtenerParametro(idGrupo, codigoAbreviatura);
        }
    }
}
