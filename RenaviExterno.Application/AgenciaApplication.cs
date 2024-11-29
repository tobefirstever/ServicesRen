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
    public class AgenciaApplication : IAgenciaApplication
    {

        private readonly IAgenciaService _agenciaService;

        public AgenciaApplication(IAgenciaService agenciaService)
        {
            _agenciaService = agenciaService;
        }
        public async Task<Response<List<AgenciaResponseDto>>> GetList(AgenciaDto request)
        {
            return await _agenciaService.GetList(request);
        }
    }
}
