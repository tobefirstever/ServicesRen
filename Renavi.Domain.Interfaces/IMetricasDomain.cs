using Renavi.Application.DTO.Dtos.Metrica;
using Renavi.Domain.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renavi.Domain.Interfaces
{
   public interface IMetricasDomain
    {
        Task<MetricaResponseDto> InsertMetrica(MetricaDto request);
    }
}
