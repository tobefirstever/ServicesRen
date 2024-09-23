using Renavi.Application.Interfaces;
using System.Threading.Tasks;
using System.Web.Http;

namespace Renavi.Services.WebApi.Controllers
{
    public class UsuarioController : ApiController
    {
        private readonly IUsuarioApplication _usuarioApplication;

        public UsuarioController(IUsuarioApplication usuarioApplication)
        {
            _usuarioApplication = usuarioApplication;
        }

        [HttpGet()]
        [Route("api/usuario")]
        public async Task<IHttpActionResult> GetList()
        {
            return Ok(await _usuarioApplication.GetList());
        }

      
    }
}
