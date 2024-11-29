using Renavi.Application.DTO.Dtos.Metrica;
using Renavi.Application.Interfaces;
using Renavi.Domain.Entities.Entities;
using Renavi.Domain.Interfaces;
using Renavi.Transversal.Common;
using Renavi.Transversal.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renavi.Application.Main
{
    public class MetricasApplication : IMetricasApplication
    {

        private readonly IMetricasDomain _metricasDomain;

        public MetricasApplication(IMetricasDomain metricasDomain)
        {
            _metricasDomain = metricasDomain;
        }

        public async Task<IEnumerable<MetricaResponseDto>> GetList(MetricaDto request)
        {
            var response = new List<MetricaResponseDto>() ;
            //IEnumerable<UsuarioEntity> gerenciaEntities = await _usuarioDomain.GetList();

            //response.Data = Mapping.Map<IEnumerable<UsuarioEntity>, IEnumerable<UsuarioDto>>(gerenciaEntities);

            /////Mejorar
            ///
            var productos = new List<MetricaResponseDto>();

            var metricas = await _metricasDomain.InsertMetrica(request);

            productos.Add(metricas);

            response = productos;

            return response;
        }
    }
}
