using Renavi.Application.DTO.Dtos.Metrica;
using Renavi.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renavi.Application.Interfaces
{
    public interface IMetricasApplication
    {
        Task<IEnumerable<MetricaResponseDto>> GetList(MetricaDto request);
    }
}
