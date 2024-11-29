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
        private readonly string _connectionStringSQL;

        public ConnectionStringProvider()
        {
            _connectionString = RegistroWindows.ObtenerCadenaRegistro(
                ConfigurationManager.AppSettings?["RutaRenavi"]?.ToString(),
                ConfigurationManager.AppSettings?["ClaveConnectionString"]?.ToString())
                ?? throw new InvalidOperationException("Connection string 'Renavi' not found.");

            _connectionStringSQL = RegistroWindows.ObtenerCadenaRegistro(
                 ConfigurationManager.AppSettings?["RutaRenavi"]?.ToString(),
                 ConfigurationManager.AppSettings?["ClaveConnectionStringSQL"]?.ToString())
                 ?? throw new InvalidOperationException("Connection string 'Renavi' not found.");
        }

        public string GetConnectionString()
        {
            return _connectionString;
        }

        public string GetConnectionStringSQL()
        {
            return _connectionStringSQL;
        }
    }
}
