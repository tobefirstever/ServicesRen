using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renavi.Application.DTO.Dtos.EntidadesTecnicas
{
    public class EntidadesTecnicasResponseDto
    {
        public List<EntidadesTecnicasDTO> EntidadesTecnicas { get; set; }

        public int TotalRegistros { get; set; }

        public int TotalRegistrosFiltrados { get; set; }


    }

    public class EntidadesTecnicasDTO
    {
        public string RazonSocial { get; set; }

        public string Ruc { get; set; }

        public string Departamento { get; set; }

        public string Provincia { get; set; }

        public string Distrito { get; set; }

        public string Clasificacion { get; set; }
    }
}
