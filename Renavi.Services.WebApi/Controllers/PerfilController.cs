
using Renavi.Application.DTO.Dtos.Usuario;
using Renavi.Application.Interfaces;
using System.Threading.Tasks;
using System.Web.Http;

namespace Renavi.Services.WebApi.Controllers
{
    public class PerfilController : ApiController
    {
        private readonly IPerfilApplication _perfilApplication;

        public PerfilController(IPerfilApplication perfilApplication)
        {
            _perfilApplication = perfilApplication;
        }

        [HttpPost()]
        [Route("api/perfil")]
        public async Task<IHttpActionResult> Registrar([FromBody] PerfilRequestDto request)
        {
            if (request == null)
            {
                return BadRequest();
            }

            return Ok(await _perfilApplication.RegistrarPerfil(request));
        }

        [HttpGet()]
        [Route("api/perfil/{id}")]
        public async Task<IHttpActionResult> Obtener(int id)
        {
            return Ok(await _perfilApplication.ObtenerPerfil(id));
        }
    }
}
