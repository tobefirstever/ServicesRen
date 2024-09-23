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
    public class DireccionDomain : IDireccionDomain
    {
        private readonly IDireccionRepository _direccionRepository;

        public DireccionDomain(IDireccionRepository direccionRepository)
        {
            _direccionRepository = direccionRepository;
        }

        public async Task<DireccionEntity> RegistarDireccion(DireccionEntity request, string usuarioRegistro)
        {
            request.UsuarioRegistro = usuarioRegistro;
            return await _direccionRepository.RegistrarDireccion(request);
        }
    }
}
