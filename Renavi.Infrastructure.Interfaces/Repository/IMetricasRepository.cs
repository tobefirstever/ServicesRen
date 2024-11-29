using Renavi.Application.DTO.Dtos.Metrica;
using Renavi.Domain.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renavi.Infrastructure.Interfaces.Repository
{
    public interface IMetricasRepository
    {
        Task<MetricaResponseDto> InsertMetrica(MetricaDto request);
    }
}
