using Renavi.Transversal.Common;
using RenaviExterno.DTO;
using RenaviExterno.Services;
using RenaviExterno.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenaviExterno.Application.Interfaces
{
    public class ParametroApplication : IParametroApplication
    {

        private readonly IParametroService _parametroService;

        public ParametroApplication(IParametroService parametroService)
        {
            _parametroService = parametroService;
        }
        public async Task<Response<List<ParametroDto>>> Buscar(string grupoParametros)
        {
            return await _parametroService.Buscar(grupoParametros);
        }
    }
}
