using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renavi.Application.DTO.Dtos.Precalificacion
{
    public class PrecalificacionDto
    {
        public int NumeroPantalla { get; set; }
        public int IdUsuario { get; set; }
        public int IdPersona { get; set; }
        public int IdPrecalificacion { get; set; }


        //////Precalificacion 1  Dirección de Domicilio
        public int TipoVia { get; set; }
        public int TipoDomicilio { get; set; }
        public string DescripcionTipoVia { get; set; }
        public int Departamento { get; set; }
        public int Provincia { get; set; }
        public int Distrito { get; set; }
        public string Numero { get; set; }
        public string Manzana { get; set; }
        public string Lote { get; set; }
        public string Referencia { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }

        //////Precalificacion 2  Información Personal
        public int Genero { get; set; }
        public int EstadoCivil { get; set; }
        public int Nacionalidad { get; set; }
        public int Edad { get; set; }

        //////Precalificacion 3  Situación Socioeconómica
        public int LugarDondeResideActualmente { get; set; }
        public string HogarConformadoPorEstasPersonas { get; set; }

        //////Precalificacion 4  Principal
        public int QueNecesita { get; set; }
        public int Principal_Departamento { get; set; }
        public int Principal_Provincia { get; set; }
        public int Principal_Distrito { get; set; }
        public int IngresoNetoFamiliarMensual { get; set; }
        public int SituacionVivienda { get; set; }
        public bool FlagViviendaInscritaRegistrosPublicos { get; set; }
        public bool FlagApoyoDelEstadoParaviviendaAntes { get; set; }
    }
}
