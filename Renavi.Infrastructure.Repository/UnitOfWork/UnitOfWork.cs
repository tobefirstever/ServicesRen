using Renavi.Infrastructure.Interfaces.Configuration;
using Renavi.Transversal.Common;
using System.Data;

namespace Renavi.Infrastructure.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbConnection _dbConnection;

        public UnitOfWork(IConnectionFactory connectionFactory)
        {
            if (connectionFactory != null) _dbConnection = connectionFactory.GetConnection();
        }

        public IDbTransaction BeginTransaction()
        {
            return _dbConnection?.BeginTransaction();
        }
    }
}
