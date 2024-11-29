using Renavi.Transversal.Common;
using RenaviExterno.DTO;
using RenaviExterno.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenaviExterno.Application.Interfaces
{
    public class MetricasApplication :IMetricasApplication
    {

        private readonly IMetricasService _metricasService;

        public MetricasApplication(IMetricasService metricasService)
        {
            _metricasService = metricasService;
        }

        public async Task<Response<List<MetricaResponseDto>>> InsertMetrica(MetricaDto request)
        {
            return await _metricasService.InsertMetrica(request);
        }
    }
}
