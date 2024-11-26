using Renavi.Application.DTO.Dtos.EntidadesTecnicas;
using Renavi.Domain.Entities.Entities;
using Renavi.Domain.Interfaces;
using Renavi.Infrastructure.Interfaces.Repository;
using Renavi.Infrastructure.Services.Cabiel.Contracts;
using Renavi.Transversal.Common.Cabiel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renavi.Domain.Main
{
    public class EntidadesTecnicasDomain : IEntidadesTecnicasDomain
    {
        private readonly IEntidadesTecnicasRepository _entidadesTecnicasRepository;

        private readonly IExternalServiceCabiel _externalServiceCabiel;

        public EntidadesTecnicasDomain(IEntidadesTecnicasRepository entidadesTecnicasRepository, IExternalServiceCabiel externalServiceCabiel)
        {
            _entidadesTecnicasRepository = entidadesTecnicasRepository;
            _externalServiceCabiel = externalServiceCabiel;
        }

        public async Task<IEnumerable<EntidadesTecnicasEntity>> GetList()
        {
            return await _entidadesTecnicasRepository.GetList();
        }

        public async Task<IEnumerable<Entidad>> ObtenerEntidadesTecnicas(RequestEntidadesTecnicasDTO request)
        {
           return await _externalServiceCabiel.ObtenerEntidadesTecnicas(request.RazonSocial, request.Ruc, request.Departamento, request.Clasificacion, request.PageIndex, request.PageSize);
 
        }
    }
}
