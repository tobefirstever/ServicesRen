using Renavi.Application.DTO.Dtos.Parametro;
using Renavi.Domain.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renavi.Transversal.Mapper.Profile
{
    public class ParametroProfile : AutoMapper.Profile
    {
        public ParametroProfile()
        {
            CreateMap<ParametroDto, ParametroEntity>()
            ?.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            ?.ForMember(dest => dest.CodigoAbreviatura, opt => opt.MapFrom(src => src.CodigoAbreviatura))
            ?.ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombre))
            .ReverseMap();

        }

    }
}
