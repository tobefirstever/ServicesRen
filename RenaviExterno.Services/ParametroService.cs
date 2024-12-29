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
    public class ParametroService : IParametroService
    {
        public async Task<Response<List<ParametroDto>>> Buscar(string grupoParametros)
        {
            var model = new Response<List<ParametroDto>> { Data = new List<ParametroDto>() };

            try
            {

                var APIURL = ConfigurationManager.AppSettings?["UrlService"]?.ToString();
                var url = $"{APIURL}/api/parametro?grupoParametros={grupoParametros}";

                HttpClient client = new HttpClient();
               string json = "";
                var requestMessage = new HttpRequestMessage();

                requestMessage.Method = new HttpMethod("GET");
               // requestMessage.Content = new StringContent(json, Encoding.UTF8, "application/json");
                requestMessage.RequestUri = new Uri(url);

                var httpResponse = await client.SendAsync(requestMessage);

                var result = await httpResponse.Content.ReadAsStringAsync();
                var datos = JsonConvert.DeserializeObject< List<ParametroDto>> (result);
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
