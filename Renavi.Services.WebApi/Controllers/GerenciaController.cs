using Renavi.Application.Interfaces;
using System.Threading.Tasks;
using System.Web.Http;

namespace Renavi.Services.WebApi.Controllers
{
    public class GerenciaController : ApiController //BaseApiController
    {

        private readonly IGerenciaApplication _gerenciaApplication;

        private readonly IUbigeoApplication _ubigeoApplication;

        public GerenciaController(IGerenciaApplication gerenciaApplication,
            IUbigeoApplication ubigeoApplication)
        {
            _gerenciaApplication = gerenciaApplication;
            _ubigeoApplication = ubigeoApplication;
        }

        [HttpGet()]
        [Route("api/gerencia")]
        public async Task<IHttpActionResult> GetList()
        {
          

            return Ok(await _ubigeoApplication.GetList());
        }

      
    }
}
