using Renavi.Application.DTO.Dtos.Usuario;
using Renavi.Domain.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renavi.Transversal.Mapper.Profile
{
   public class UsuarioProfile : AutoMapper.Profile
    {
        public UsuarioProfile()
        {
            CreateMap<ContactoDto, ContactoEntity>()
                 ?.ForMember(dest => dest.IdContacto, opt => opt.MapFrom(src => src.IdContacto))
                 ?.ForMember(dest => dest.NroCelular, opt => opt.MapFrom(src => src.NroCelular))
                  ?.ForMember(dest => dest.Correo, opt => opt.MapFrom(src => src.Correo))
                  .ReverseMap();

            CreateMap<DireccionDto, DireccionEntity>()
                 ?.ForMember(dest => dest.IdDireccion, opt => opt.MapFrom(src => src.IdDireccion))
                 ?.ForMember(dest => dest.IdTipoVia, opt => opt.MapFrom(src => src.IdTipoVia))
                  ?.ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombre))
                   ?.ForMember(dest => dest.Nro, opt => opt.MapFrom(src => src.Nro))
                    ?.ForMember(dest => dest.Mza, opt => opt.MapFrom(src => src.Mza))
                     ?.ForMember(dest => dest.Lote, opt => opt.MapFrom(src => src.Lote))
                      ?.ForMember(dest => dest.IdDepartamento, opt => opt.MapFrom(src => src.IdDepartamento))
                       ?.ForMember(dest => dest.IdProvincia, opt => opt.MapFrom(src => src.IdProvincia))
                        ?.ForMember(dest => dest.IdDistrito, opt => opt.MapFrom(src => src.IdDistrito))
                         ?.ForMember(dest => dest.IdTipoDomicilio, opt => opt.MapFrom(src => src.IdTipoDomicilio))
                          ?.ForMember(dest => dest.DireccionReferencia, opt => opt.MapFrom(src => src.DireccionReferencia))
                           ?.ForMember(dest => dest.CodigoPostal, opt => opt.MapFrom(src => src.CodigoPostal))
                           ?.ForMember(dest => dest.Latitud, opt => opt.MapFrom(src => src.Latitud))
                           ?.ForMember(dest => dest.Longitud, opt => opt.MapFrom(src => src.Longitud))
                  .ReverseMap();


            CreateMap<PersonaDto, PersonaEntity>()
               ?.ForMember(dest => dest.IdPersona, opt => opt.MapFrom(src => src.IdPersona))
              ?.ForMember(dest => dest.IdTipoDocumento, opt => opt.MapFrom(src => src.IdTipoDocumento))
              ?.ForMember(dest => dest.NroDocumento, opt => opt.MapFrom(src => src.NroDocumento))
              ?.ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombre))
              ?.ForMember(dest => dest.ApellidoPaterno, opt => opt.MapFrom(src => src.ApellidoPaterno))
              ?.ForMember(dest => dest.ApellidoMaterno, opt => opt.MapFrom(src => src.ApellidoMaterno))
              ?.ForMember(dest => dest.InformacionContacto , opt => opt.MapFrom(src => src.InformacionContacto))
              ?.ForMember(dest => dest.DireccionDomicilio, opt => opt.MapFrom(src => src.DireccionDomicilio))
                .ReverseMap();

        }
    }
}
