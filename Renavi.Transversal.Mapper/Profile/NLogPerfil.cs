using Renavi.Application.DTO;
using Renavi.Domain.Entities.Custom;

namespace Renavi.Transversal.Mapper.Profile
{
    public class NLogPerfil : AutoMapper.Profile
    {
        public NLogPerfil()
        {
            CreateMap<NLog, NLogDto>()
                ?.ForMember(dest => dest.Id, opt => opt?.MapFrom(src => src.Id))
                ?.ForMember(dest => dest.Hostname, opt => opt?.MapFrom(src => src.Hostname))
                ?.ForMember(dest => dest.Mensaje, opt => opt?.MapFrom(src => src.Mensaje))
                ?.ForMember(dest => dest.FechaHora, opt => opt?.MapFrom(src => src.FechaHora))
                ?.ForMember(dest => dest.Cantidad, opt => opt?.MapFrom(src => src.Cantidad))
                ?.ReverseMap();

            CreateMap<NLog, NLogForCreationRequestDto>()
                ?.ForMember(dest => dest.Hostname, opt => opt?.MapFrom(src => src.Hostname))
                ?.ForMember(dest => dest.Mensaje, opt => opt?.MapFrom(src => src.Mensaje))
                ?.ReverseMap();

            CreateMap<NLog, NLogForUpdateRequestDto>()
                ?.ForMember(dest => dest.Hostname, opt => opt?.MapFrom(src => src.Hostname))
                ?.ForMember(dest => dest.Mensaje, opt => opt?.MapFrom(src => src.Mensaje))
                ?.ReverseMap();
        }
    }
}
