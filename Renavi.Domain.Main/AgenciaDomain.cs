using Renavi.Application.DTO.Dtos.Agencia;
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
    public class AgenciaDomain : IAgenciaDomain
    {
        private readonly IAgenciaRepository _agenciaRepository;

        public AgenciaDomain(IAgenciaRepository agenciaRepository)
        {
            _agenciaRepository = agenciaRepository;
        }

        public async Task<List<AgenciaResponseDto>> GetList()
        {
            return await _agenciaRepository.GetList();
        }
    }
}
