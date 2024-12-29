using Renavi.Application.DTO.Dtos.Ubigeo;
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
    public class UbigeoApplication : IUbigeoApplication
    {
        private readonly IUbigeoDomain _ubigeoDomain;

        public UbigeoApplication(IUbigeoDomain ubigeoDomain)
        {
            _ubigeoDomain = ubigeoDomain;
        }


        public async Task<IEnumerable<UbigeoResponseDto>> GetList(UbigeoDto request)
        {
            var response = new List<UbigeoResponseDto>();
            IEnumerable<UbigeoEntity> gerenciaEntities = await _ubigeoDomain.GetList();
            var listado = obtenerDatos(gerenciaEntities, request.IdDepartamento, request.IdProvincia);

            response = Mapping.Map<IEnumerable<UbigeoEntity>, IEnumerable<UbigeoResponseDto>>(listado).ToList();
            return response;
        }

        public async Task<IEnumerable<UbigeoResponseDto>> GetListAll()
        {
            var response = new List<UbigeoResponseDto>();
            IEnumerable<UbigeoEntity> gerenciaEntities = await _ubigeoDomain.GetList();
            response = Mapping.Map<IEnumerable<UbigeoEntity>, IEnumerable<UbigeoResponseDto>>(gerenciaEntities).ToList();
            return response;
        }

        public IEnumerable<UbigeoEntity> obtenerDatos(IEnumerable<UbigeoEntity> gerenciaEntities, int Departamento, int Provincia)
        {

            var listado = gerenciaEntities;


            if (Departamento == 0 && Provincia == 0)
            {
                listado = gerenciaEntities.Where(x => x.IdProvincia == 0 && x.IdDistrito==0);
            }


            if (Departamento != 0 && Provincia == 0)
            {
                listado = gerenciaEntities.Where(x => x.IdDepartamento == Departamento && x.IdDistrito==0 && x.IdProvincia!=0);
            }

            if (Departamento != 0 && Provincia != 0)
            {
                listado = gerenciaEntities.Where(x => x.IdDepartamento == Departamento && x.IdProvincia==Provincia && x.IdDistrito!=0);
            }

            return listado;
        }
    }
}
