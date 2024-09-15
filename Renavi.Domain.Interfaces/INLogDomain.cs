using Renavi.Domain.Entities.Custom;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Renavi.Domain.Interfaces
{
    public interface INLogDomain
    {
        void Add(NLog nLog);
        Task AddAsync(NLog nLog);
        void Delete(int id);
        Task DeleteAsync(int id);
        IEnumerable<NLog> GetAll();
        Task<IEnumerable<NLog>> GetAllAsync();
        IEnumerable<NLog> GetAllPaging(int pageNumber, int pageSize);
        Task<IEnumerable<NLog>> GetAllPagingAsync(int pageNumber, int pageSize);
        NLog GetById(int id);
        Task<NLog> GetByIdAsync(int id);
        void Update(NLog nLog);
        Task UpdateAsync(NLog nLog);
    }
}
