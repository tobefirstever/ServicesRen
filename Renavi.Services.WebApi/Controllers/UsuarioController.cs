using Renavi.Application.DTO.Dtos.Usuario;
using Renavi.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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

        [HttpPost()]
        [Route("api/usuarioregistrar")]
        public async Task<IHttpActionResult> RegistroUsuario(UsuarioDto request)
        {
            return Ok(await _usuarioApplication.RegistroUsuario(request));
        }

        [HttpPost()]
        [Route("api/EnvioCorreoPassword")]
        public async Task<IHttpActionResult> EnvioCorreoPassword(UsuarioCorreonDto request)
        {
            return Ok(await _usuarioApplication.EnvioCorreoPassword(request));
        }

        [HttpPost()]
        [Route("api/ActualizarPassword")]
        public async Task<IHttpActionResult> ActualizarPassword(UsuarioACtualizarDto request)
        {
            return Ok(await _usuarioApplication.ActualizarPassword(request));
        }

        [HttpPost()]
        [Route("api/Login")]
        public async Task<IHttpActionResult> Login(UsuarioAutenticacionDto request)
        {
            return Ok(await _usuarioApplication.Login(request));
        }
    }
}
