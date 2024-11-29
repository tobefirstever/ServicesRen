using Renavi.Application.DTO.Dtos.Metrica;
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
    public class MetricasDomain : IMetricasDomain
    {
        private readonly IMetricasRepository _metricasRepository;

        public MetricasDomain(IMetricasRepository metricasRepository)
        {
            _metricasRepository = metricasRepository;
        }

        public async Task<MetricaResponseDto> InsertMetrica(MetricaDto request)
        {
            return await _metricasRepository.InsertMetrica(request);
        }
    }
}
