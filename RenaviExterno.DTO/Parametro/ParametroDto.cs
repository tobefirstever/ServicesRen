using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenaviExterno.DTO
{
    public class ParametroDto
    {
        public int IdParametro { get; set; }

        public string CodigoParametro { get; set; }

        public int IdDetalleParametro { get; set; }

        public string CodigoDetalleParametro { get; set; }

        public string Descripcion { get; set; }

        public string Valor1 { get; set; }

        public string Valor2 { get; set; }

        public string Valor3 { get; set; }
    }
}
