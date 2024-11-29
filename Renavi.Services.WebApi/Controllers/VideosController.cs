using Renavi.Application.DTO.Dtos.Videos;
using Renavi.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Renavi.Services.WebApi.Controllers
{
    public class VideosController : ApiController
    {
        private readonly IVideoApplication _videoApplication;

        public VideosController(IVideoApplication videoApplication)
        {
            _videoApplication = videoApplication;
        }

        [HttpPost()]
        [Route("api/videos")]
        public async Task<IHttpActionResult> GetList()
        {
            return Ok(await _videoApplication.GetList());
        }
        [HttpGet()]
        [Route("api/Archivovideos/{ruta}")]
        public async Task<HttpResponseMessage> GetListArchivo(string ruta)

        {

            var response = await _videoApplication.GetArchivo(ruta);
            HttpResponseMessage httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK);
            httpResponseMessage.Content = new StreamContent(new MemoryStream(response.Data.ToList()[0].archivo));
            httpResponseMessage.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
            httpResponseMessage.Content.Headers.ContentDisposition.FileName = ruta + ".mp4";
            httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");

            return httpResponseMessage;


        }
    }
}
