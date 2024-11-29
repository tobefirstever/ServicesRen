using System;
using System.Configuration;
using System.Data;
using System.Data.Common;
using Renavi.Infrastructure.Interfaces.Configuration;
using Renavi.Transversal.Common;

namespace Renavi.Infrastructure.Configuration
{
    public class ConnectionFactory : IConnectionFactory
    {
        private readonly string _connectionString;
        private readonly string _connectionStringSQL;


        public ConnectionFactory(IConnectionStringProvider  connectionStringProvider)
        {
            _connectionString = connectionStringProvider.GetConnectionString();
            _connectionStringSQL = connectionStringProvider.GetConnectionStringSQL();
        }


        public IDbConnection GetConnection()
        {
            var factory = DbProviderFactories.GetFactory(Constantes.OracleClient);
            var conn = factory.CreateConnection();

            if (conn == null)
            {
                throw new InvalidOperationException("Failed to create a connection using the provided factory.");
            }

            conn.ConnectionString = _connectionString;

            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                // Logger.LogError(ex, "Error opening database connection");
                conn.Dispose();
                throw;
            }

            return conn;
        }

        public IDbConnection GetConnectionSQL()
        {
            var factory = DbProviderFactories.GetFactory(Constantes.SQLClient);
            var conn = factory.CreateConnection();

            if (conn == null)
            {
                throw new InvalidOperationException("Failed to create a connection using the provided factory.");
            }

            conn.ConnectionString = _connectionStringSQL;

            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                // Logger.LogError(ex, "Error opening database connection");
                conn.Dispose();
                throw;
            }

            return conn;
        }
    }
}
