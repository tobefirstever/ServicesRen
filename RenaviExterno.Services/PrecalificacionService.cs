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
    public class PrecalificacionService : IPrecalificacionService
    {
        public async Task<Response<ObtenerPrecalificacionResponseDto>> GetPrecalificacion(ObtenerPrecalificacionDto request)
        {
            var model = new Response<ObtenerPrecalificacionResponseDto> { Data = new ObtenerPrecalificacionResponseDto() };

            try
            {

                var APIURL = ConfigurationManager.AppSettings?["UrlService"]?.ToString();
                var url = $"{APIURL}/api/ObtenerPrecalificacion";

                HttpClient client = new HttpClient();
                string json = JsonConvert.SerializeObject(request);
                var requestMessage = new HttpRequestMessage();

                requestMessage.Method = new HttpMethod("POST");
                requestMessage.Content = new StringContent(json, Encoding.UTF8, "application/json");
                requestMessage.RequestUri = new Uri(url);

                var httpResponse = await client.SendAsync(requestMessage);

                var result = await httpResponse.Content.ReadAsStringAsync();
                var datos = JsonConvert.DeserializeObject<ObtenerPrecalificacionResponseDto>(result);
                model.Data = datos;

                return model;

            }

            catch (Exception ex)
            {
                return model;
            }
        }

        public async Task<Response<ObtenerRespuestaResponseDto>> GetRespuesta(ObtenerRespuestaDto request)
        {
            var model = new Response<ObtenerRespuestaResponseDto> { Data = new ObtenerRespuestaResponseDto() };

            try
            {

                var APIURL = ConfigurationManager.AppSettings?["UrlService"]?.ToString();
                var url = $"{APIURL}/api/ObtenerRespuesta";

                HttpClient client = new HttpClient();
                string json = JsonConvert.SerializeObject(request);
                var requestMessage = new HttpRequestMessage();

                requestMessage.Method = new HttpMethod("POST");
                requestMessage.Content = new StringContent(json, Encoding.UTF8, "application/json");
                requestMessage.RequestUri = new Uri(url);

                var httpResponse = await client.SendAsync(requestMessage);

                var result = await httpResponse.Content.ReadAsStringAsync();
                var datos = JsonConvert.DeserializeObject<ObtenerRespuestaResponseDto>(result);
                model.Data = datos;

                return model;

            }

            catch (Exception ex)
            {
                return model;
            }
        }

        public async Task<Response<PrecalificacionResponseDto>> InsertarPrecalificacion(PrecalificacionDto request)
        {
            var model = new Response<PrecalificacionResponseDto> { Data = new PrecalificacionResponseDto() };

            try
            {

                var APIURL = ConfigurationManager.AppSettings?["UrlService"]?.ToString();
                var url = $"{APIURL}/api/InsertarPrecalificacion";

                HttpClient client = new HttpClient();
                string json = JsonConvert.SerializeObject(request);
                var requestMessage = new HttpRequestMessage();

                requestMessage.Method = new HttpMethod("POST");
                requestMessage.Content = new StringContent(json, Encoding.UTF8, "application/json");
                requestMessage.RequestUri = new Uri(url);

                var httpResponse = await client.SendAsync(requestMessage);

                var result = await httpResponse.Content.ReadAsStringAsync();
                var datos = JsonConvert.DeserializeObject<PrecalificacionResponseDto>(result);
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
