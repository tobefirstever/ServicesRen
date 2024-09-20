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
                    RUC = row["RUC"].ToString(),
                    RAZONSOCIAL = row["RAZONSOCIAL"].ToString(),
                    CIIU = row["CIIU"].ToString(),
                    FEC_CONSTITUCION = row["FEC_CONSTITUCION"].ToString(),
                    FEC_INI_ACT = row["FEC_INI_ACT"].ToString(),
                    DIRECCION = row["DIRECCION"].ToString(),
                    DEPARTAMENTO = row["DEPARTAMENTO"].ToString(),
                    PROVINCIA = row["PROVINCIA"].ToString(),
                    DISTRITO = row["DISTRITO"].ToString(),
                    CANCELADO = row["CANCELADO"].ToString(),
                    CLASIFICACION = row["CLASIFICACION"].ToString(),
                    PUNTAJE = row["PUNTAJE"].ToString(),
                    COMPORTAMIENTO = row["COMPORTAMIENTO"].ToString(),
                    TRAYECTORIA = row["TRAYECTORIA"].ToString(),
                    PERFORMANCE_FMV = row["PERFORMANCE_FMV"].ToString(),
                    SOLIDEZ = row["SOLIDEZ"].ToString(),
                    SCORE_AJUSTE = row["SCORE_AJUSTE"].ToString(),
                    SCORE_OC = row["SCORE_OC"].ToString(),
                    FEC_INGRESO = row["FEC_INGRESO"].ToString(),
                    FEC_CONSTITUCION_X = row["FEC_CONSTITUCION_X"].ToString(),
                    FEC_INI_ACT_X = row["FEC_INI_ACT_X"].ToString(),
                    CIIU_X = row["CIIU_X"].ToString()
                };
                listaEntidades.Add(entidad);
            }

            return listaEntidades;
        }
    }
}
