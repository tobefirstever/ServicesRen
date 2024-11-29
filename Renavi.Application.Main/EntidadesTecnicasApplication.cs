using Renavi.Application.DTO.Dtos.EntidadesTecnicas;
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
    public class EntidadesTecnicasApplication : IEntidadesTecnicasApplication
    {
        private readonly IEntidadesTecnicasDomain _entidadesTenicasRepository;

     

        public EntidadesTecnicasApplication(IEntidadesTecnicasDomain entidadesTenicasRepository)
        {
            _entidadesTenicasRepository = entidadesTenicasRepository;
        }


        public async Task<Response<IEnumerable<EntidadesTecnicasDto>>> GetList()
        {
            var respuesta = new Response<IEnumerable<EntidadesTecnicasDto>> { Data = new List<EntidadesTecnicasDto>() };
            try
            {
                IEnumerable<EntidadesTecnicasEntity> entidadesTecnicas = await _entidadesTenicasRepository.GetList();
                respuesta.Data = Mapping.Map<IEnumerable<EntidadesTecnicasEntity>, IEnumerable<EntidadesTecnicasDto>>(entidadesTecnicas);
            }
            catch (Exception ex)
            {
                respuesta.IsSuccess = false;
                respuesta.Message = Mensajes.ErrorEnconsulta;
                
            }
            return respuesta;
        }


        public async Task<EntidadesTecnicasResponseDto> ObtenerEntidadesTecnicas(List<EntidadesTecnicas> lista,EntidadesTecnicasDto request)
        {
            var resultado = new EntidadesTecnicasResponseDto();

            var listaEntidades = Mapping.Map<IEnumerable<EntidadesTecnicas>, IEnumerable<EntidadesTecnicasDTO>>(lista).ToList();

            int totalRegistros = listaEntidades.Count;

            var listaFiltrada = listaEntidades.Where(e =>
                (string.IsNullOrEmpty(request.RazonSocial) || e.RazonSocial.Contains(request.RazonSocial)) &&
                (string.IsNullOrEmpty(request.Ruc) || e.Ruc.Contains(request.Ruc)) &&
                (string.IsNullOrEmpty(request.Departamento) || e.Departamento == request.Departamento) &&
                (string.IsNullOrEmpty(request.Clasificacion) || e.Clasificacion == request.Clasificacion)).ToList();

            int totalRegistrosFiltrados = listaFiltrada.Count;


            var datosPaginados = listaFiltrada.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize).ToList();

            resultado.EntidadesTecnicas = datosPaginados;
            resultado.TotalRegistros = totalRegistros;
            resultado.TotalRegistrosFiltrados = totalRegistrosFiltrados;

            return resultado;
        }
    }
}
