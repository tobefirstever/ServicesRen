using System.Web.Http;
using Renavi.Application.DTO;
using Renavi.Services.WebApi.Core;

namespace Renavi.Services.WebApi.Controllers
{
    /// <summary>
    /// Controlador que contiene todas las apis de Autenticación
    /// </summary>    
    public class AuthController : ApiController
    {
        /// <summary>
        /// Realiza la autenticación del usuario
        /// </summary>
        /// <param name="usuarioLoginDto"></param>
        /// <returns></returns>
        [HttpPost()]
        [Route("api/auth")]
        public IHttpActionResult Login([FromBody] UsuarioLoginRequestDto usuarioLoginDto)
        {
            if (usuarioLoginDto == null)
            {
                return BadRequest();
            }

            /* Inyectar el  Cerbero.Services.Client y realizar la validacion de version y autenticacion
             CerberoResult ValidarVersion
             CerberoResult AutenticarUsuario
            */


            string authToken = TokenGenerator.GenerateTokenJwt(usuarioLoginDto.Username);
            return Ok(
                new Transversal.Common.Response<UsuarioLoginResponseDto>
                {
                    Data = new UsuarioLoginResponseDto
                    {
                        Username = usuarioLoginDto.Username,
                        AuthToken = authToken
                    }
                });
        }
    }
}