using System.Data;

namespace Renavi.Infrastructure.Interfaces.Configuration
{
    public interface IConnectionFactory
    {
        IDbConnection GetConnection();
        IDbConnection GetConnectionSQL();
    }
}
