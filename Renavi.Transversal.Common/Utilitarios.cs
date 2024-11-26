using Renavi.Transversal.Common.Cabiel;
using System.Collections.Generic;
using System.Data;

namespace Renavi.Transversal.Common
{
    public static class Utilitarios
    {
        public static List<Entidad> ConvertirDataTableALista(DataTable dt)
        {
            var listaEntidades = new List<Entidad>();

            foreach (DataRow row in dt.Rows)
            {
                var entidad = new Entidad
                {
                    RUC = row.Field<string>("RUC"),
                    RAZONSOCIAL = row.Field<string>("RAZONSOCIAL"),
                    CIIU = row.Field<string>("CIIU"),
                    FEC_CONSTITUCION = row.Field<string>("FEC_CONSTITUCION"),
                    FEC_INI_ACT = row.Field<string>("FEC_INI_ACT"),
                    DIRECCION = row.Field<string>("DIRECCION"),
                    DEPARTAMENTO = row.Field<string>("DEPARTAMENTO"),
                    PROVINCIA = row.Field<string>("PROVINCIA"),
                    DISTRITO = row.Field<string>("DISTRITO"),
                    CANCELADO = row.Field<string>("CANCELADO"),
                    CLASIFICACION = row.Field<string>("CLASIFICACION"),
                    PUNTAJE = row.Field<string>("PUNTAJE"),
                    COMPORTAMIENTO = row.Field<string>("COMPORTAMIENTO"),
                    TRAYECTORIA = row.Field<string>("TRAYECTORIA"),
                    PERFORMANCE_FMV = row.Field<string>("PERFORMANCE_FMV"),
                    SOLIDEZ = row.Field<string>("SOLIDEZ"),
                    SCORE_AJUSTE = row.Field<string>("SCORE_AJUSTE"),
                    SCORE_OC = row.Field<string>("SCORE_OC"),
                    FEC_INGRESO = row.Field<string>("FEC_INGRESO"),
                    FEC_CONSTITUCION_X = row.Field<string>("FEC_CONSTITUCION_X"),
                    FEC_INI_ACT_X = row.Field<string>("FEC_INI_ACT_X"),
                    CIIU_X = row.Field<string>("CIIU_X")
                };
                listaEntidades.Add(entidad);
            }

            return listaEntidades;
        }
    }
}
