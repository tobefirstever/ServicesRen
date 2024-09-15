using Renavi.Application.DTO;
using Renavi.Transversal.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Renavi.Application.Interfaces
{
    public interface INLogApplication
    {
        Response<bool> Add(NLogForCreationRequestDto nLogForCreationRequestDto);
        Task<Response<bool>> AddAsync(NLogForCreationRequestDto nLogForCreationRequestDto);
        Response<bool> Delete(int id);
        Task<Response<bool>> DeleteAsync(int id);
        Response<IEnumerable<NLogDto>> GetAll();
        Task<Response<IEnumerable<NLogDto>>> GetAllAsync();
        Response<IEnumerable<NLogDto>> GetAllPaging(int pageNumber, int pageSize);
        Task<Response<IEnumerable<NLogDto>>> GetAllPagingAsync(int pageNumber, int pageSize);
        Response<NLogDto> GetById(int id);
        Task<Response<NLogDto>> GetByIdAsync(int id);
        Response<bool> Update(NLogForUpdateRequestDto nLogForUpdateRequestDto);
        Task<Response<bool>> UpdateAsync(NLogForUpdateRequestDto nLogForUpdateRequestDto);
    }
}
