using Renavi.Application.DTO.Dtos.EntidadesTecnicas;
using Renavi.Application.Interfaces;
using Renavi.Domain.Entities.Entities;
using Renavi.Domain.Interfaces;
using Renavi.Transversal.Common;
using Renavi.Transversal.Common.Cabiel;
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


        public async Task<Response<IEnumerable<EntidadesTecnicasDTO>>> GetList()
        {
            var respuesta = new Response<IEnumerable<EntidadesTecnicasDTO>> { Data = new List<EntidadesTecnicasDTO>() };
          
                IEnumerable<EntidadesTecnicasEntity> entidadesTecnicas = await _entidadesTenicasRepository.GetList();
                respuesta.Data = Mapping.Map<IEnumerable<EntidadesTecnicasEntity>, IEnumerable<EntidadesTecnicasDTO>>(entidadesTecnicas);
           
           
                respuesta.IsSuccess = false;
                respuesta.Message = Mensajes.ErrorEnconsulta;
                
           
            return respuesta;
        }

        public async Task<GeneralResponse> ObtenerEntidadesTecnicas(RequestEntidadesTecnicasDTO request)
        {
            var resultado = new ResultadoEntidadesTecnicasDTO();
            var listaEntidades = Mapping.Map<IEnumerable<Entidad>, IEnumerable<EntidadesTecnicasDTO>>(await _entidadesTenicasRepository.ObtenerEntidadesTecnicas(request)).ToList();
            int totalRegistros = listaEntidades.Count;
            int totalRegistrosFiltrados = listaEntidades.Count;
            var datosPaginados = listaEntidades.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize).ToList();
            resultado.EntidadesTecnicas = datosPaginados;
            resultado.TotalRegistros = totalRegistros;
            resultado.TotalRegistrosFiltrados = totalRegistrosFiltrados;

            return new GeneralResponse
            {
                Data = resultado,
                Success = true,
                Message = Mensajes.PROCESO_EXITOSO
            };
        }
    }
}
