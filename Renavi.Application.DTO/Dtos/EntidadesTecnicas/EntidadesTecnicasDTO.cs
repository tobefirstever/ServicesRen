using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renavi.Application.DTO.Dtos.EntidadesTecnicas
{
    public class EntidadesTecnicasDto
    {
        public string RazonSocial { get; set; }

        public string Ruc { get; set; }

        public string Departamento { get; set; }

        public string Clasificacion { get; set; }

        public int PageIndex { get; set; }

        public int PageSize { get; set; }

    
    }
}
