using System.Collections.Generic;
using System.Threading.Tasks;
using Renavi.Domain.Entities.Custom;
using Renavi.Domain.Interfaces;
using Renavi.Infrastructure.Interfaces.Repository;

namespace Renavi.Domain.Main
{
    public class NLogDomain : INLogDomain
    {
        private readonly INLogRepository _nLogRepository;

        public NLogDomain(INLogRepository nLogRepository)
        {
            _nLogRepository = nLogRepository;
        }

        public void Add(NLog nLog)
        {
            _nLogRepository?.Add(nLog);
        }

        public async Task AddAsync(NLog nLog)
        {
            await _nLogRepository.AddAsync(nLog);
        }

        public void Delete(int id)
        {
            _nLogRepository?.Delete(id);
        }

        public async Task DeleteAsync(int id)
        {
            await _nLogRepository.DeleteAsync(id);
        }

        public IEnumerable<NLog> GetAll()
        {
            return _nLogRepository?.GetAll();
        }

        public async Task<IEnumerable<NLog>> GetAllAsync()
        {
            return await _nLogRepository.GetAllAsync();
        }

        public IEnumerable<NLog> GetAllPaging(int pageNumber, int pageSize)
        {
            return _nLogRepository?.GetAllPaging(pageNumber, pageSize);
        }

        public async Task<IEnumerable<NLog>> GetAllPagingAsync(int pageNumber, int pageSize)
        {
            return await _nLogRepository.GetAllPagingAsync(pageNumber, pageSize);
        }

        public NLog GetById(int id)
        {
            return _nLogRepository?.GetById(id);
        }

        public async Task<NLog> GetByIdAsync(int id)
        {
            return await _nLogRepository.GetByIdAsync(id);
        }

        public void Update(NLog nLog)
        {
            _nLogRepository?.Update(nLog);
        }

        public async Task UpdateAsync(NLog nLog)
        {
            await _nLogRepository.UpdateAsync(nLog);
        }
    }
}
