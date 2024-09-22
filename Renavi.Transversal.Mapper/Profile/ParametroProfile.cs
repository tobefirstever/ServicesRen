using Renavi.Application.DTO.Dtos.Parametro;
using Renavi.Domain.Entities.Entities;


namespace Renavi.Transversal.Mapper.Profile
{
    public class ParametroProfile : AutoMapper.Profile
    {
        public ParametroProfile()
        {
            CreateMap<ParametroDto, ParametroEntity>()
            ?.ForMember(dest => dest.IdParametro, opt => opt.MapFrom(src => src.IdParametro))
            ?.ForMember(dest => dest.CodigoParametro, opt => opt.MapFrom(src => src.CodigoParametro))
            ?.ForMember(dest => dest.IdDetalleParametro, opt => opt.MapFrom(src => src.IdDetalleParametro))
            ?.ForMember(dest => dest.CodigoDetalleParametro, opt => opt.MapFrom(src => src.CodigoDetalleParametro))
            ?.ForMember(dest => dest.Descripcion, opt => opt.MapFrom(src => src.Descripcion))
            ?.ForMember(dest => dest.Valor1, opt => opt.MapFrom(src => src.Valor1))
            ?.ForMember(dest => dest.Valor1, opt => opt.MapFrom(src => src.Valor2))
            ?.ForMember(dest => dest.Valor1, opt => opt.MapFrom(src => src.Valor3))
            .ReverseMap();
        }
    }
}
