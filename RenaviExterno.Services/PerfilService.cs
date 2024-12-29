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
    public class PerfilService : IPerfilService
    {
        public async Task<Response<string>> ActualizarPersona(EditarPerfilModel personaEntity)
        {
            var model = new Response<string> { Data = "" };

            try
            {

                var APIURL = ConfigurationManager.AppSettings?["UrlService"]?.ToString();
                var url = $"{APIURL}/api/perfil";

                HttpClient client = new HttpClient();
                string json = JsonConvert.SerializeObject(personaEntity);
                var requestMessage = new HttpRequestMessage();

                requestMessage.Method = new HttpMethod("PUT");
                requestMessage.Content = new StringContent(json, Encoding.UTF8, "application/json");
                requestMessage.RequestUri = new Uri(url);

                var httpResponse = await client.SendAsync(requestMessage);

                var result = await httpResponse.Content.ReadAsStringAsync();
                var datos = JsonConvert.DeserializeObject<string>(result);
                model.Data = datos;

                return model;

            }

            catch (Exception ex)
            {
                return model;
            }
        }

        public async Task<Response<PersonaDto>> ObtenerPerfil(int id)
        {
            var model = new Response<PersonaDto> { Data = new PersonaDto() };

            try
            {

                var APIURL = ConfigurationManager.AppSettings?["UrlService"]?.ToString();
                var url = $"{APIURL}/api/perfil/{id}";

                HttpClient client = new HttpClient();
                string json = "";
                var requestMessage = new HttpRequestMessage();

                requestMessage.Method = new HttpMethod("GET");
                // requestMessage.Content = new StringContent(json, Encoding.UTF8, "application/json");
                requestMessage.RequestUri = new Uri(url);

                var httpResponse = await client.SendAsync(requestMessage);

                var result = await httpResponse.Content.ReadAsStringAsync();
                var datos = JsonConvert.DeserializeObject<PersonaDto>(result);
                model.Data = datos;

                return model;

            }

            catch (Exception ex)
            {
                return model;
            }
        }

        public async Task<Response<bool>> RegistrarPerfil(PerfilRequestDto perfilRequestDto)
        {
            var model = new Response<bool> { Data = new bool() };

            try
            {

                var APIURL = ConfigurationManager.AppSettings?["UrlService"]?.ToString();
                var url = $"{APIURL}/api/perfil";

                HttpClient client = new HttpClient();
                string json = JsonConvert.SerializeObject(perfilRequestDto);
                var requestMessage = new HttpRequestMessage();

                requestMessage.Method = new HttpMethod("POST");
                requestMessage.Content = new StringContent(json, Encoding.UTF8, "application/json");
                requestMessage.RequestUri = new Uri(url);

                var httpResponse = await client.SendAsync(requestMessage);

                var result = await httpResponse.Content.ReadAsStringAsync();
                var datos = JsonConvert.DeserializeObject<bool>(result);
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
