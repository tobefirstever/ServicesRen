using Renavi.Infrastructure.Services.ServiceCabiel;
using System;
using System.Configuration;
using System.ServiceModel;
using Unity;
using Unity.Lifetime;

namespace Renavi.Transversal.IoC
{
    public static class Startup
    {
        public static void RegisterSoapClient(IUnityContainer container, string baseAddressKey)
        {

            string url = ConfigurationManager.AppSettings[baseAddressKey];

            if (string.IsNullOrEmpty(url))
            {
                throw new ConfigurationErrorsException($"La URL del servicio SOAP para {baseAddressKey} no está configurada.");
            }

            container.RegisterFactory<ServicioWEBSoapClient>(c =>
            {
                var binding = new BasicHttpBinding
                {
                    SendTimeout = TimeSpan.FromMinutes(10),
                    ReceiveTimeout = TimeSpan.FromMinutes(10),
                    OpenTimeout = TimeSpan.FromMinutes(10),
                    CloseTimeout = TimeSpan.FromMinutes(10),
                    MaxBufferPoolSize = 2147483647,
                    MaxBufferSize = 2147483647,
                    MaxReceivedMessageSize = 2147483647
                };

                var endpointAddress = new EndpointAddress(url);
                var cliente = new ServicioWEBSoapClient(binding, endpointAddress);

                return cliente;
            }, new HierarchicalLifetimeManager());
        }
    }
}
