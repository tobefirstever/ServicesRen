using Renavi.Application.DTO.Dtos.Gerencia;
using Renavi.Domain.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renavi.Transversal.Mapper.Profile
{
    public class GerenciaProfile : AutoMapper.Profile
    {
        public GerenciaProfile()
        {
            CreateMap<GerenciaEntity, GerenciaDto>()
                ?.ForMember(dest => dest.Id, opt => opt?.MapFrom(src => src.Id))
                ?.ForMember(dest => dest.Nombre, opt => opt?.MapFrom(src => src.Nombre))
                ?.ForMember(dest => dest.Estado, opt => opt?.MapFrom(src => src.Estado))
                .ReverseMap();

        }
    }
}
