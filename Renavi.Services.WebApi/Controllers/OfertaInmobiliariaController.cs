using Renavi.Application.DTO.Dtos.OfertaInmobiliaria;
using Renavi.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Services;

namespace Renavi.Services.WebApi.Controllers
{
    public class OfertaInmobiliariaController : ApiController
    {
        private readonly IOfertaInmobiliariaApplication _ofertaInmobiliariaApplication;

        public OfertaInmobiliariaController(IOfertaInmobiliariaApplication ofertaInmobiliariaApplication)
        {
            _ofertaInmobiliariaApplication = ofertaInmobiliariaApplication;
        }


        [HttpPost()]
        [Route("api/ofertainmobiliaria")]
        public async Task<IHttpActionResult> GetList(OfertaInmobiliariaDto request)
        {
            var Wsi = new ServicioWebPortal.ServicioWEBSoapClient();
            var ListadoAgencias = Wsi.ListarProyectosWeb("CMV");

            var lista = new List<OfertaInmobiliariaResponseDto>();
            foreach (DataRow row in ListadoAgencias.Rows)
            {
                var objeto = new OfertaInmobiliariaResponseDto();
                if (request.Opcion == "CMV")
                {
                    objeto.strproyecto = row["strproyecto"].ToString();
                    objeto.strpromotor = row["strpromotor"].ToString();
                    objeto.strdireccion = row["strdireccion"].ToString();
                    objeto.decareatechmin = Convert.ToDecimal( row["decareatechmin"]);
                    objeto.decareatechmax = Convert.ToDecimal(row["decareatechmax"]);
                    objeto.decpreciomin = Convert.ToDecimal(row["decpreciomin"]);
                    objeto.decpreciomax = Convert.ToDecimal(row["decpreciomax"]);
                    objeto.intverde =Convert.ToInt32(row["intverde"]);
                    objeto.strdepartamento = row["strdepartamento"].ToString();
                    objeto.strprovincia = row["strprovincia"].ToString();
                    objeto.strdistrito = row["strdistrito"].ToString();
                    objeto.strlink = row["strlink"].ToString();
                    objeto.strperiodopub = row["strperiodopub"].ToString();  
                    lista.Add(objeto);
                }
                else if (request.Opcion == "TP")
                {
                    objeto.strproyecto = row["strproyecto"].ToString();
                    objeto.strcodproyecto = row["strcodproyecto"].ToString();
                    objeto.strpromotor = row["strpromotor"].ToString();
                    objeto.strdireccion = row["strdireccion"].ToString();
                    objeto.decofertadisp = Convert.ToDecimal(row["decofertadisp"]);
                    objeto.decprecioprom = (Convert.ToDecimal(row["decpreciomin"]) + Convert.ToDecimal(row["decpreciomax"])) / 2;
                    objeto.decareatechprom = (Convert.ToDecimal(row["decareatechmin"]) + Convert.ToDecimal(row["decareatechmax"])) / 2;
                    objeto.decarealotemin = Convert.ToDecimal(row["decarealotemin"]);
                    objeto.decarealotemax = Convert.ToDecimal(row["decarealotemax"]);
                    objeto.decareatechmin = Convert.ToDecimal(row["decareatechmin"]);
                    objeto.decareatechmax = Convert.ToDecimal(row["decareatechmax"]);
                    objeto.decpreciomin = Convert.ToDecimal(row["decpreciomin"]);
                    objeto.decpreciomax = Convert.ToDecimal(row["decpreciomax"]);
                    objeto.decarealoteprom = (Convert.ToDecimal(row["decarealotemin"]) + Convert.ToDecimal(row["decarealotemax"])) / 2;
                    objeto.strtelefono = row["strtelefono"].ToString();
                    objeto.strcontacto = row["strcontacto"].ToString();
                    objeto.intverde = Convert.ToInt32(row["intverde"]);
                    objeto.strdepartamento = row["strdepartamento"].ToString();
                    objeto.strprovincia = row["strprovincia"].ToString();
                    objeto.strdistrito = row["strdistrito"].ToString();
                    objeto.strperiodopub = row["strperiodopub"].ToString();
                    lista.Add(objeto);
                }
            }
            //return Ok(lista);
            return Ok(await _ofertaInmobiliariaApplication.GetList(lista, request));
        }
    }
}
