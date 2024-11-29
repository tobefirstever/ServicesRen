using Renavi.Application.DTO.Dtos.Ubigeo;
using Renavi.Domain.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renavi.Transversal.Mapper.Profile
{
   public class UbigeoProfile : AutoMapper.Profile
    {

        public UbigeoProfile()
        {
            CreateMap<UbigeoResponseDto, UbigeoEntity>()
                 ?.ForMember(dest => dest.IdUbigeo, opt => opt.MapFrom(src => src.IdUbigeo))
                  ?.ForMember(dest => dest.IdDepartamento, opt => opt.MapFrom(src => src.IdDepartamento))
                   ?.ForMember(dest => dest.IdProvincia, opt => opt.MapFrom(src => src.IdProvincia))
                    ?.ForMember(dest => dest.IdDistrito, opt => opt.MapFrom(src => src.IdDistrito))
                     ?.ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombre)).ReverseMap();
        }
    }
}
