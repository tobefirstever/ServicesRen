using System.Threading.Tasks;
using System.Web.Http;
using Renavi.Application.DTO;
using Renavi.Application.Interfaces;

namespace Renavi.Services.WebApi.Controllers
{
    /// <summary>
    /// Controlador que contiene todas las apis de NLog
    /// </summary>
    public class NLogController : BaseApiController
    {
        private readonly INLogApplication _nLogApplication;

        /// <summary>
        /// Constructor de la controlador
        /// </summary>
        /// <param name="nLogApplication">Inyección de dependencia</param>
        public NLogController(INLogApplication nLogApplication)
        {
            _nLogApplication = nLogApplication;
        }

        /// <summary>
        /// Crea un registro de NLog (Necesita token)
        /// </summary>
        /// <param name="nLogForCreationRequestDto"></param>
        /// <returns></returns>
        [HttpPost()]
        [Route("api/nLog")]
        public async Task<IHttpActionResult> AddAsync([FromBody]NLogForCreationRequestDto nLogForCreationRequestDto)
        {
            if (nLogForCreationRequestDto == null)
            {
                return BadRequest();
            }

            return Ok(await _nLogApplication.AddAsync(nLogForCreationRequestDto));
        }

        /// <summary>
        /// Elimina por identificador (Necesita token)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete()]
        [Route("api/nLog/{id}")]
        public async Task<IHttpActionResult> DeleteAsync(int id)
        {
            var nLogReturn = await _nLogApplication.GetByIdAsync(id);
            if (nLogReturn.Data == null)
            {
                return NotFound();
            }

            return Ok(await _nLogApplication.DeleteAsync(id));
        }

        /// <summary>
        /// Obtener NLog por Identificador (Necesita token)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet()]
        [Route("api/nLog/{id}")]
        public async Task<IHttpActionResult> GetNLogAsync(int id)
        {
            var nLogReturn = await _nLogApplication.GetByIdAsync(id);
            if (nLogReturn.Data == null)
            {
                return NotFound();
            }

            return Ok(nLogReturn);
        }

        /// <summary>
        /// Obtiene lista de registros NLog (Necesita token)
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        [Route("api/nLog")]
        public async Task<IHttpActionResult> GetNLogsAsync()
        {
            return Ok(await _nLogApplication.GetAllAsync());
        }

        /// <summary>
        /// Obtiene lista paginada de registros NLog (Necesita token)
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet()]
        [Route("api/nLog/{pageNumber}/{pageSize}")]
        public async Task<IHttpActionResult> GetNLogsPagingAsync(int pageNumber = 1, int pageSize = 20)
        {
            return Ok(await _nLogApplication.GetAllPagingAsync(pageNumber, pageSize));
        }        

        /// <summary>
        /// Actualiza un registro de Log (Necesita token)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nLogForUpdateRequestDto"></param>
        /// <returns></returns>
        [HttpPut()]
        [Route("api/nLog/{id}")]
        public async Task<IHttpActionResult> UpdateAsync(int id, [FromBody]NLogForUpdateRequestDto nLogForUpdateRequestDto)
        {
            if (nLogForUpdateRequestDto == null)
            {
                return BadRequest();
            }

            var nLogReturn = await _nLogApplication.GetByIdAsync(id);
            if (nLogReturn.Data == null)
            {
                return NotFound();
            }
            nLogForUpdateRequestDto.Id = id;
            return Ok(await _nLogApplication.UpdateAsync(nLogForUpdateRequestDto));
        }
    }
}