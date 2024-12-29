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

        public PerfilApplication(IContactoDomain contactoDomain, IDireccionDomain direccionDomain, IPersonaDomain personaDomain)
        {
            _contactoDomain = contactoDomain;
            _direccionDomain = direccionDomain;
            _personaDomain = personaDomain;
        }

        public async Task<bool> RegistrarPerfil(PerfilRequestDto perfilRequestDto)
        {
            bool response=false;

            if (perfilRequestDto == null || perfilRequestDto.InformacionPersonal == null ||  perfilRequestDto.InformacionPersonal.DireccionDomicilio == null)
            {
                throw new InvalidOperationException(Mensajes.ERROR_PERFIL_DATA);
            }


           // var contactoRequest = perfilRequestDto.InformacionPersonal.InformacionContacto;

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


               // var contactoEntity = await (_contactoDomain ?? throw new InvalidOperationException("_contactoDomain no está inicializado.")).RegistrarContacto(Mapping.Map<ContactoDto, ContactoEntity>(contactoRequest), usuarioCreacion);
                var direccionEntity = await (_direccionDomain ?? throw new InvalidOperationException("_direccionDomain no está inicializado.")).RegistarDireccion(Mapping.Map<DireccionDto, DireccionEntity>(direccionRequest), usuarioCreacion);

                personaRequest.DireccionDomicilio.IdDireccion = direccionEntity.IdDireccion;
               // personaRequest.InformacionContacto.IdContacto = contactoEntity.IdContacto;
                await _personaDomain.RegistrarPersona(Mapping.Map<PersonaDto, PersonaEntity>(personaRequest), usuarioCreacion);

                response = true;
                transaccion.Complete();
            }

            return response;
        }

        public async Task<PersonaDto> ObtenerPerfil(int id)
        {
            var response =  new PersonaDto() ;
            response = Mapping.Map<PersonaEntity, PersonaDto>(await _personaDomain.ObtenerPersona(id));

            return response;

        }

        public async Task<string> ActualizarPersona(EditarPerfilModel personaEntity)
        {
            var response = await _personaDomain.ActualizarPersona(personaEntity);

            return response;
        }
    }
}
