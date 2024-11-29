using Microsoft.VisualBasic.CompilerServices;
using Org.BouncyCastle.Asn1.Ocsp;
using Renavi.Application.DTO.Dtos.OfertaInmobiliaria;
using Renavi.Application.Interfaces;
using Renavi.Domain.Entities.Entities;
using Renavi.Domain.Interfaces;
using Renavi.Transversal.Common;
using Renavi.Transversal.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renavi.Application.Main
{
    public class OfertaInmobiliariaApplication : IOfertaInmobiliariaApplication
    {
        private readonly IOfertaInmobiliariaDomain _ofertaInmobiliariaDomain;

        public OfertaInmobiliariaApplication(IOfertaInmobiliariaDomain ofertaInmobiliariaDomain)
        {
            _ofertaInmobiliariaDomain = ofertaInmobiliariaDomain;
        }


        public async Task<IEnumerable<OfertaInmobiliariaResponseDto>> GetList(List<OfertaInmobiliariaResponseDto> lista, OfertaInmobiliariaDto request )
        {
            var response = new List<OfertaInmobiliariaResponseDto>();
            //IEnumerable<OfertaInmobiliariaEntity> gerenciaEntities = await _ofertaInmobiliariaDomain.GetList();

            //response.Data = Mapping.Map<IEnumerable<OfertaInmobiliariaEntity>, IEnumerable<OfertaInmobiliariaDto>>(gerenciaEntities);
            //return response;

            if (!string.IsNullOrEmpty(request.nombres))
                lista = lista.Where(x => x.strproyecto.ToLower().Contains(request.nombres.ToLower())).ToList();
            if (!string.IsNullOrEmpty(request.departamento) & !(request.departamento == "--Seleccione--"))
                lista = lista.Where(x => StringExtensionMatch(x.strdepartamento) == request.departamento.ToLower().Trim()).ToList();
            if (!string.IsNullOrEmpty(request.provincia) & !(request.provincia == "--Seleccione--"))
                lista = lista.Where(x => StringExtensionMatch(x.strprovincia) == request.provincia.ToLower().Trim()).ToList();
            if (!string.IsNullOrEmpty(request.distrito) & !(request.distrito == "--Seleccione--"))
                lista = lista.Where(x => StringExtensionMatch(x.strdistrito) == request.distrito.ToLower().Trim()).ToList();

            if (!string.IsNullOrEmpty(request.areamin) & !string.IsNullOrEmpty(request.areamax))
            {
                var lista4 = new List<OfertaInmobiliariaResponseDto>();
                var lista5 = new List<OfertaInmobiliariaResponseDto>();
                var lista6 = new List<OfertaInmobiliariaResponseDto>();

                lista4 = lista.Where(x => x.decareatechmin > Convert.ToDecimal( request.areamin) & x.decareatechmin <= Convert.ToDecimal(request.areamax)).ToList();
                lista5 = lista.Where(x => x.decareatechmax < Convert.ToDecimal(request.areamax) & x.decareatechmax >= Convert.ToDecimal(request.areamin)).ToList();
                lista6 = lista.Where(x => x.decareatechmin <= Convert.ToDecimal(request.areamin) & x.decareatechmax >= Convert.ToDecimal(request.areamax)).ToList();
                lista4.AddRange(lista5);
                lista4.AddRange(lista6);
                lista = lista4;
            }
            else if (!string.IsNullOrEmpty(request.areamin) & string.IsNullOrEmpty(request.areamax))
            {
                lista = lista.Where(x => x.decareatechmax >= Convert.ToDecimal(request.areamin)).ToList();
            }
            else if (string.IsNullOrEmpty(request.areamin) & !string.IsNullOrEmpty(request.areamax))
            {
                lista = lista.Where(x => x.decareatechmin <= Convert.ToDecimal(request.areamax)).ToList();
            }

            if (!string.IsNullOrEmpty(request.arealotemin) & !string.IsNullOrEmpty(request.arealotemax))
            {
                var lista7 = new List<OfertaInmobiliariaResponseDto>();
                var lista8 = new List<OfertaInmobiliariaResponseDto>();
                var lista9 = new List<OfertaInmobiliariaResponseDto>();

                lista7 = lista.Where(x => x.decarealotemin > Convert.ToDecimal(request.arealotemin) & x.decarealotemin <= Convert.ToDecimal(request.arealotemax)).ToList();
                lista8 = lista.Where(x => x.decarealotemax < Convert.ToDecimal(request.arealotemax) & x.decarealotemax >= Convert.ToDecimal(request.arealotemin)).ToList();
                lista9 = lista.Where(x => x.decarealotemin <= Convert.ToDecimal(request.arealotemin) & x.decarealotemax >= Convert.ToDecimal(request.arealotemax)).ToList();
                lista7.AddRange(lista8);
                lista7.AddRange(lista9);
                lista = lista7;
            }
            else if (!string.IsNullOrEmpty(request.arealotemin) & string.IsNullOrEmpty(request.arealotemax))
            {
                lista = lista.Where(x => x.decarealotemax >= Convert.ToDecimal(request.arealotemin)).ToList();
            }
            else if (string.IsNullOrEmpty(request.arealotemin) & !string.IsNullOrEmpty(request.arealotemax))
            {
                lista = lista.Where(x => x.decarealotemin <= Convert.ToDecimal(request.arealotemax)).ToList();
            }

            if (!string.IsNullOrEmpty(request.preciomin) & !string.IsNullOrEmpty(request.preciomax))
            {
                var lista1 = new List<OfertaInmobiliariaResponseDto>();
                var lista2 = new List<OfertaInmobiliariaResponseDto>();
                var lista3 = new List<OfertaInmobiliariaResponseDto>();

                lista1 = lista.Where(x => x.decpreciomin > Convert.ToDecimal(request.preciomin) & x.decpreciomin <= Convert.ToDecimal(request.preciomax)).ToList();
                lista2 = lista.Where(x => x.decpreciomax < Convert.ToDecimal(request.preciomax) & x.decpreciomax >= Convert.ToDecimal(request.preciomin)).ToList();
                lista3 = lista.Where(x => x.decpreciomin <= Convert.ToDecimal(request.preciomin) & x.decpreciomax >= Convert.ToDecimal(request.preciomax)).ToList();
                lista1.AddRange(lista2);
                lista1.AddRange(lista3);
                lista = lista1;
            }
            else if (!string.IsNullOrEmpty(request.preciomin) & string.IsNullOrEmpty(request.preciomax))
            {
                lista = lista.Where(x => x.decpreciomax >= Convert.ToDecimal(request.preciomin)).ToList();
            }
            else if (string.IsNullOrEmpty(request.preciomin) & !string.IsNullOrEmpty(request.preciomax))
            {
                lista = lista.Where(x => x.decpreciomin <= Convert.ToDecimal(request.preciomax)).ToList();
            }

            if (!string.IsNullOrEmpty(request.bonoverde))
            {
                if (request.bonoverde == "0")
                {
                    lista = lista.Where(x => x.intverde==0 || x.intverde==1 || x.intverde==2).ToList();
                }
                else if (request.bonoverde == "1")
                {
                    lista = lista.Where(x => x.intverde == 1 || x.intverde == 2).ToList();
                }

            }

            response = lista;

            return response;


        }

        private string StringExtensionMatch(string parametro)
        {
            parametro = parametro.ToLower().Trim().Replace("á", "a").Replace("é", "e").Replace("í", "i").Replace("ó", "o").Replace("ú", "u");
            return parametro;
        }
    }
}
