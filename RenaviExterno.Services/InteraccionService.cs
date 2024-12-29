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
    public class InteraccionService : IInteraccionService
    {
        public async Task<Response<InteraccionResponseDto>> InsertInteraccion(InteraccionDto request)
        {
            var model = new Response<InteraccionResponseDto> { Data = new InteraccionResponseDto() };

            try
            {

                var APIURL = ConfigurationManager.AppSettings?["UrlService"]?.ToString();
                var url = $"{APIURL}/api/interaccion";

                HttpClient client = new HttpClient();
                string json = JsonConvert.SerializeObject(request);
                var requestMessage = new HttpRequestMessage();

                requestMessage.Method = new HttpMethod("POST");
                requestMessage.Content = new StringContent(json, Encoding.UTF8, "application/json");
                requestMessage.RequestUri = new Uri(url);

                var httpResponse = await client.SendAsync(requestMessage);

                var result = await httpResponse.Content.ReadAsStringAsync();
                var datos = JsonConvert.DeserializeObject<InteraccionResponseDto>(result);
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
