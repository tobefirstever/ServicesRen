using Renavi.Application.DTO.Dtos.EntidadesTecnicas;
using Renavi.Transversal.Common.Cabiel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renavi.Transversal.Mapper.Profile
{
    public class EntidadTecnicaProfile : AutoMapper.Profile
    {
        public EntidadTecnicaProfile()
        {
            CreateMap<EntidadesTecnicasDTO, Entidad>()
                 ?.ForMember(dest => dest.RAZONSOCIAL, opt => opt.MapFrom(src => src.RazonSocial))
                 ?.ForMember(dest => dest.RUC, opt => opt.MapFrom(src => src.Ruc))
                 ?.ForMember(dest => dest.DEPARTAMENTO, opt => opt.MapFrom(src => src.Departamento))
                 ?.ForMember(dest => dest.PROVINCIA, opt => opt.MapFrom(src => src.Provincia))
                 ?.ForMember(dest => dest.DISTRITO, opt => opt.MapFrom(src => src.Distrito))
                 ?.ForMember(dest => dest.CLASIFICACION, opt => opt.MapFrom(src => src.Clasificacion))
                 .ReverseMap();
        }
    }
}
