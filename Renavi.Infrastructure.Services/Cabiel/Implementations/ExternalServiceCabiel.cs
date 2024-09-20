using Renavi.Infrastructure.Services.Cabiel.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Renavi.Infrastructure.Services.Cabiel.Base;
using Renavi.Transversal.Common.Cabiel;
using Renavi.Transversal.Common;

namespace Renavi.Infrastructure.Services.Cabiel.Implementations
{
    public class ExternalServiceCabiel : IExternalServiceCabiel
    {
        private readonly IClientCabiel _clientCabiel;

        public ExternalServiceCabiel(IClientCabiel clientCabiel)
        {
            _clientCabiel = clientCabiel;
        }

        public async Task<List<Entidad>> ObtenerEntidadesTecnicas(string razonSocial, string ruc, string departamento, string clasificacion)
        {
            var response = await _clientCabiel.GetEntidadesTecnicas(razonSocial, ruc, departamento, clasificacion);
            var listaEntidades = Utilitarios.ConvertirDataTableALista(response);
            return listaEntidades;
        }
    }
}
