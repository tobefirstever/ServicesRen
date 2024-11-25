using Renavi.Application.DTO.Dtos.Usuario;
using Renavi.Application.Interfaces;
using Renavi.Domain.Entities.Entities;
using Renavi.Domain.Interfaces;
using Renavi.Transversal.Common;
using Renavi.Transversal.Mapper;
using System;
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
            _contactoDomain =   contactoDomain;
            _direccionDomain = direccionDomain;
            _personaDomain = personaDomain;
        }

        public async Task<GeneralResponse> RegistrarPerfil(PerfilRequestDto perfilRequestDto)
        {
            var response = new Response<bool>();

            if (perfilRequestDto == null || perfilRequestDto.InformacionPersonal == null || perfilRequestDto.InformacionPersonal.InformacionContacto == null || perfilRequestDto.InformacionPersonal.DireccionDomicilio == null)
            {
                throw new InvalidOperationException(Mensajes.ERROR_PERFIL_DATA);
            }


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


                var contactoEntity = await (_contactoDomain ?? throw new InvalidOperationException("_contactoDomain no está inicializado.")).RegistrarContacto(Mapping.Map<ContactoDto, ContactoEntity>(contactoRequest), usuarioCreacion);
                var direccionEntity = await (_direccionDomain ?? throw new InvalidOperationException("_direccionDomain no está inicializado.")).RegistarDireccion(Mapping.Map<DireccionDto, DireccionEntity>(direccionRequest), usuarioCreacion);

                personaRequest.DireccionDomicilio.IdDireccion = direccionEntity.IdDireccion;
                personaRequest.InformacionContacto.IdContacto = contactoEntity.IdContacto;
                await _personaDomain.RegistrarPersona(Mapping.Map<PersonaDto, PersonaEntity>(personaRequest), usuarioCreacion);

                response.Data = true;
                transaccion.Complete();
            }

            return new GeneralResponse
            {
                Data = null,
                Message = Mensajes.PROCESO_EXITOSO,
                Success = true
            };
        }

        public async Task<GeneralResponse> ObtenerPerfil(int id)
        {
            var response = new Response<PersonaDto> { Data = new PersonaDto() };
            response.Data = Mapping.Map<PersonaEntity, PersonaDto>(await _personaDomain.ObtenerPersona(id));

            return new GeneralResponse
            {
                Data = response.Data,
                Message = Mensajes.PROCESO_EXITOSO,
                Success = true
            };
        }
    }
}
