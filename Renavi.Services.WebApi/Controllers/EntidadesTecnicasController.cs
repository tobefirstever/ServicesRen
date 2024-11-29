using Renavi.Application.DTO.Dtos.EntidadesTecnicas;
using Renavi.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Data;

namespace Renavi.Services.WebApi.Controllers
{
    public class EntidadesTecnicasController : ApiController
    {
        private readonly IEntidadesTecnicasApplication _entidadesTecnicasApplication;


        public EntidadesTecnicasController(IEntidadesTecnicasApplication entidadesTecnicasApplication)
        {
            _entidadesTecnicasApplication = entidadesTecnicasApplication;
        }


        [HttpPost()]
        [Route("api/entidadestecnicas")]
        public async Task<IHttpActionResult> GetList(EntidadesTecnicasDto request)
        {

            var Wsi = new ServicioWebPortal.ServicioWEBSoapClient();
            var ListadoEntidades = Wsi.ObtenerListaET(string.Empty, string.Empty, string.Empty, request.Clasificacion);

            var listaEntidades = new List<EntidadesTecnicas>();

            foreach (DataRow row in ListadoEntidades.Rows)
            {
                var entidad = new EntidadesTecnicas
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

            return Ok(await _entidadesTecnicasApplication.ObtenerEntidadesTecnicas(listaEntidades,request));
        }
    }
}

