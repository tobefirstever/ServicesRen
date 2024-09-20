using Renavi.Infrastructure.Services.ServiceCabiel;
using System;
using System.Data;
using System.Threading.Tasks;

namespace Renavi.Infrastructure.Services.Cabiel.Base
{
    public  class ClientCabiel : IClientCabiel , IDisposable
    {
        private readonly ServicioWEBSoapClient _servicioWEBSoapClient;

        public ClientCabiel(ServicioWEBSoapClient servicioWEBSoapClient)
        {
            _servicioWEBSoapClient = servicioWEBSoapClient;
        }

        public ServicioWEBSoapClient GetServicioWEBSoapClient()
        {
            return _servicioWEBSoapClient;
        }
      
        public async Task<DataTable> GetEntidadesTecnicas(string razonSocial, string ruc, string departamento, string clasificacion)
        {
            return await _servicioWEBSoapClient.ObtenerListaETAsync(razonSocial, ruc, departamento, clasificacion);
        }

        public void Dispose()
        {
            _servicioWEBSoapClient?.Close(); 
        }
    }
}
