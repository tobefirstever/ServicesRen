using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenaviExterno.DTO
{
   public class ObtenerPrecalificacionResponseDto
    {

        public int? idusuario { get; set; }
        public int? idpersona { get; set; }
        public int? idprecalificacion { get; set; }


        //////Precalificacion 1  Dirección de Domicilio
        public int? tipovia { get; set; }
        public int? tipodomicilio { get; set; }
        public string descripciontipovia { get; set; }
        public int? departamento { get; set; }
        public int? provincia { get; set; }
        public int? distrito { get; set; }
        public string numero { get; set; }
        public string manzana { get; set; }
        public string lote { get; set; }
        public string referencia { get; set; }
        public string latitud { get; set; }
        public string longitud { get; set; }

        //////Precalificacion 2  Información Personal
        public int? genero { get; set; }
        public int? estadocivil { get; set; }
        public int nacionalidad { get; set; }
        public int? edad { get; set; }

        //////Precalificacion 3  Situación Socioeconómica
        public int? lugardonderesideactualmente { get; set; }
        public string hogarconformadoporestaspersonas { get; set; }

        //////Precalificacion 4  Principal
        public int? quenecesita { get; set; }
        public int? principal_departamento { get; set; }
        public int? principal_provincia { get; set; }
        public int? principal_distrito { get; set; }
        public int? ingresonetofamiliarmensual { get; set; }
        public int? situacionvivienda { get; set; }
        public int? flagviviendainscritaregistrospublicos { get; set; }
        public int? flagapoyodelestadoparaviviendaantes { get; set; }
    }
}
