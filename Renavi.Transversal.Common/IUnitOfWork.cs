using System.Data;

namespace Renavi.Transversal.Common
{
    public interface IUnitOfWork
    {
        IDbTransaction BeginTransaction();
    }
}
