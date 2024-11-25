using Renavi.Infrastructure.Services.ServiceCabiel;
using System;
using System.Data;
using System.Threading.Tasks;

namespace Renavi.Infrastructure.Services.Cabiel.Base
{
    public  class ClientCabiel : IClientCabiel , IDisposable
    {
        private readonly ServicioWEBSoapClient _servicioWEBSoapClient;
        private bool _disposed = false;  

        public ClientCabiel(ServicioWEBSoapClient servicioWEBSoapClient)
        {
            _servicioWEBSoapClient = servicioWEBSoapClient ?? throw new ArgumentNullException(nameof(servicioWEBSoapClient));
        }

        public ServicioWEBSoapClient GetServicioWEBSoapClient()
        {
            ThrowIfDisposed();
            return _servicioWEBSoapClient;
        }

        public async Task<DataTable> GetEntidadesTecnicas(string razonSocial, string ruc, string departamento, string clasificacion)
        {
            ThrowIfDisposed();
            return await _servicioWEBSoapClient.ObtenerListaETAsync(razonSocial, ruc, departamento, clasificacion);
        }

        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this); 
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                   
                    if (_servicioWEBSoapClient != null)
                    {
                        try
                        {
                            if (_servicioWEBSoapClient.State == System.ServiceModel.CommunicationState.Opened)
                            {
                                _servicioWEBSoapClient.Close();  
                            }
                        }
                        catch (Exception)
                        {
                            _servicioWEBSoapClient.Abort();  
                        }
                    }
                }
 

                _disposed = true;  
            }
        }

        
        private void ThrowIfDisposed()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(nameof(ClientCabiel), "El objeto ya fue eliminado y no puede ser utilizado.");
            }
        }

        
        ~ClientCabiel()
        {
            Dispose(false);
        }
    }
}
