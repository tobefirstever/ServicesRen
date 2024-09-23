using Renavi.Application.DTO.Dtos.Usuario;
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
using System.Transactions;

namespace Renavi.Application.Main
{
    public class PerfilApplication : IPerfilApplication
    {
        private readonly IContactoDomain _contactoDomain;

        private readonly IDireccionDomain _direccionDomain;

        private readonly IPersonaDomain _personaDomain;

        public PerfilApplication(IContactoDomain contactoDomain, IDireccionDomain direccionDomain , IPersonaDomain personaDomain)
        {
            _contactoDomain = contactoDomain;
            _direccionDomain = direccionDomain;
            _personaDomain = personaDomain;
        }

        public async Task<Response<bool>> RegistrarPerfil(PerfilRequestDto perfilRequestDto)
        {
            var response = new Response<bool>();

            var contactoRequest = perfilRequestDto.InformacionPersonal.InformacionContacto;

            var direccionRequest = perfilRequestDto.InformacionPersonal.DireccionDomicilio;

            var personaRequest = perfilRequestDto.InformacionPersonal;

            var usuarioCreacion = perfilRequestDto.UsuarioCreacion;

            var options = new TransactionOptions
            {
                IsolationLevel = IsolationLevel.ReadCommitted,
                Timeout = TimeSpan.FromTicks(Constantes.TimeoutTransaccion)
            };

            using (var transaccion = new TransactionScope(TransactionScopeOption.Required, options))
            {
                try
                {
                    if (perfilRequestDto == null)
                    {
                        response.IsWarning = true;
                        response.Message = Mensajes.ErrorAlRegistrarDataInvalida;
                        return response;
                    }

                    var contactoEntity = await _contactoDomain?.RegistrarContacto(Mapping.Map<ContactoDto, ContactoEntity>(contactoRequest), usuarioCreacion);
                    var direccionEntity = await _direccionDomain?.RegistarDireccion(Mapping.Map<DireccionDto, DireccionEntity>(direccionRequest), usuarioCreacion);

                    personaRequest.DireccionDomicilio.IdDireccion = direccionEntity.IdDireccion;
                    personaRequest.InformacionContacto.IdContacto = contactoEntity.IdContacto;

                    var idPersona = await _personaDomain.RegistrarPersona(Mapping.Map<PersonaDto, PersonaEntity>(personaRequest), usuarioCreacion);

                    response.Data = true;
                    transaccion.Complete();
                }
                catch (Exception ex)
                {
                    response.IsSuccess = false;
                    response.Message = Mensajes.ERROR_REGISTRO_CONTACTO;
                    //  Logger?.Error(exception, exception.Message);
                }
            }

            return response;
        }

        public async Task<Response<PersonaDto>> ObtenerPerfil(int id)
        {
            var response = new Response<PersonaDto> { Data = new PersonaDto() };

            try
            {
                var data = await _personaDomain.ObtenerPersona(id);

                response.Data = Mapping.Map<PersonaEntity, PersonaDto>(data);
            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Mensajes.ERROR_REGISTRO_CONTACTO;
            }

            return response;
        }
    }
}
