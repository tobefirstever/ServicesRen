using Renavi.Infrastructure.Interfaces.Configuration;
using Renavi.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renavi.Infrastructure.Configuration
{
    public class ConnectionStringProvider : IConnectionStringProvider
    {
        private readonly string _connectionString;

        public ConnectionStringProvider()
        {
            _connectionString = RegistroWindows.ObtenerCadenaRegistro(
                ConfigurationManager.AppSettings?["RutaRenavi"]?.ToString(),
                ConfigurationManager.AppSettings?["ClaveConnectionString"]?.ToString())
                ?? throw new InvalidOperationException("Connection string 'Renavi' not found.");
        }

        public string GetConnectionString()
        {
            return _connectionString;
        }
    }
}
