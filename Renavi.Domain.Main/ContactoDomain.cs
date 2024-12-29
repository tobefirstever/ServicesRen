using Renavi.Domain.Entities.Entities;
using Renavi.Domain.Interfaces;
using Renavi.Infrastructure.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renavi.Domain.Main
{
    public class ContactoDomain : IContactoDomain
    {
        private readonly IContactoRepository _contactoRepository;

        public ContactoDomain(IContactoRepository contactoRepository)
        {
            _contactoRepository = contactoRepository;
        }

        public async Task<ContactoEntity> RegistrarContacto(ContactoEntity contactoEntity, string usuarioCreacion)
        {
            contactoEntity.UsuarioRegistro = usuarioCreacion;

            return await _contactoRepository.RegistrarContacto(contactoEntity);
        }
    }
}
