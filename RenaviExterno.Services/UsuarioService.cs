using Newtonsoft.Json;
using Renavi.Transversal.Common;
using RenaviExterno.DTO;
using RenaviExterno.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RenaviExterno.Services
{
    public class UsuarioService : IUsuarioService
    {
        public async Task<Response<UsuarioGeneralResponseDto>> ActualizarPassword(UsuarioACtualizarDto request)
        {
            var model = new Response<UsuarioGeneralResponseDto> { Data = new UsuarioGeneralResponseDto() };

            try
            {

                var APIURL = ConfigurationManager.AppSettings?["UrlService"]?.ToString();
                var url = $"{APIURL}/api/ActualizarPassword";

                HttpClient client = new HttpClient();
                string json = JsonConvert.SerializeObject(request);
                var requestMessage = new HttpRequestMessage();

                requestMessage.Method = new HttpMethod("POST");
                requestMessage.Content = new StringContent(json, Encoding.UTF8, "application/json");
                requestMessage.RequestUri = new Uri(url);

                var httpResponse = await client.SendAsync(requestMessage);

                var result = await httpResponse.Content.ReadAsStringAsync();
                var datos = JsonConvert.DeserializeObject<UsuarioGeneralResponseDto>(result);
                model.Data = datos;

                return model;

            }

            catch (Exception ex)
            {
                return model;
            }
        }

        public async Task<Response<UsuarioGeneralResponseDto>> EnvioCorreoPassword(UsuarioCorreonDto request)
        {
            var model = new Response<UsuarioGeneralResponseDto> { Data = new UsuarioGeneralResponseDto() };

            try
            {

                var APIURL = ConfigurationManager.AppSettings?["UrlService"]?.ToString();
                var url = $"{APIURL}/api/EnvioCorreoPassword";

                HttpClient client = new HttpClient();
                string json = JsonConvert.SerializeObject(request);
                var requestMessage = new HttpRequestMessage();

                requestMessage.Method = new HttpMethod("POST");
                requestMessage.Content = new StringContent(json, Encoding.UTF8, "application/json");
                requestMessage.RequestUri = new Uri(url);

                var httpResponse = await client.SendAsync(requestMessage);

                var result = await httpResponse.Content.ReadAsStringAsync();
                var datos = JsonConvert.DeserializeObject<UsuarioGeneralResponseDto>(result);
                model.Data = datos;

                return model;

            }

            catch (Exception ex)
            {
                return model;
            }
        }

        public async Task<Response<UsuarioResponseDto>> Login(UsuarioAutenticacionDto request)
        {
            var model = new Response<UsuarioResponseDto> { Data = new UsuarioResponseDto() };

            try
            {

                var APIURL = ConfigurationManager.AppSettings?["UrlService"]?.ToString();
                var url = $"{APIURL}/api/Login";

                HttpClient client = new HttpClient();
                string json = JsonConvert.SerializeObject(request);
                var requestMessage = new HttpRequestMessage();

                requestMessage.Method = new HttpMethod("POST");
                requestMessage.Content = new StringContent(json, Encoding.UTF8, "application/json");
                requestMessage.RequestUri = new Uri(url);

                var httpResponse = await client.SendAsync(requestMessage);

                var result = await httpResponse.Content.ReadAsStringAsync();
                var datos = JsonConvert.DeserializeObject<UsuarioResponseDto>(result);
                model.Data = datos;

                return model;

            }

            catch (Exception ex)
            {
                return model;
            }
        }

        public async Task<Response<UsuarioResponseDto>> RegistroUsuario(UsuarioDto request)
        {
            var model = new Response<UsuarioResponseDto> { Data = new UsuarioResponseDto() };

            try
            {

                var APIURL = ConfigurationManager.AppSettings?["UrlService"]?.ToString();
                var url = $"{APIURL}/api/usuarioregistrar";

                HttpClient client = new HttpClient();
                string json = JsonConvert.SerializeObject(request);
                var requestMessage = new HttpRequestMessage();

                requestMessage.Method = new HttpMethod("POST");
                requestMessage.Content = new StringContent(json, Encoding.UTF8, "application/json");
                requestMessage.RequestUri = new Uri(url);

                var httpResponse = await client.SendAsync(requestMessage);

                var result = await httpResponse.Content.ReadAsStringAsync();
                var datos = JsonConvert.DeserializeObject<UsuarioResponseDto>(result);
                model.Data = datos;

                return model;

            }

            catch (Exception ex)
            {
                return model;
            }
        }
    }
}
