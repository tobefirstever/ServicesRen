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
    public class SimuladorCuotasService : ISimuladorCuotasService
    {
        public async Task<Response<SimuladorCronogramaResponseDto>> GetCronograma(SimuladorCronogramaDto request)
        {
            var model = new Response<SimuladorCronogramaResponseDto> { Data = new SimuladorCronogramaResponseDto() }; 

            try
            {

                var APIURL = ConfigurationManager.AppSettings?["UrlService"]?.ToString();
                var url = $"{APIURL}/api/Cronograma";

                HttpClient client = new HttpClient();
                string json = JsonConvert.SerializeObject(request);
                var requestMessage = new HttpRequestMessage();

                requestMessage.Method = new HttpMethod("POST");
                requestMessage.Content = new StringContent(json, Encoding.UTF8, "application/json");
                requestMessage.RequestUri = new Uri(url);

                var httpResponse = await client.SendAsync(requestMessage);

                var result = await httpResponse.Content.ReadAsStringAsync();
                var datos = JsonConvert.DeserializeObject<SimuladorCronogramaResponseDto>(result);
                model.Data = datos;

                return model;

            }

            catch (Exception ex)
            {
                return model;
            }
        }

        public async Task<Response<SimuladorCuotasComprasResponseDto>> GetList(SimuladorCuotasComprasDto request)
        {
            var model = new Response<SimuladorCuotasComprasResponseDto> { Data = new SimuladorCuotasComprasResponseDto() };

            try
            {

                var APIURL = ConfigurationManager.AppSettings?["UrlService"]?.ToString();
                var url = $"{APIURL}/api/simuladorcuotascompras";

                HttpClient client = new HttpClient();
                string json = JsonConvert.SerializeObject(request);

                var requestMessage = new HttpRequestMessage();

                requestMessage.Method = new HttpMethod("POST");
                requestMessage.Content = new StringContent(json, Encoding.UTF8, "application/json");
                requestMessage.RequestUri = new Uri(url);

                var httpResponse = await client.SendAsync(requestMessage);

                var result = await httpResponse.Content.ReadAsStringAsync();
                var datos = JsonConvert.DeserializeObject<SimuladorCuotasComprasResponseDto>(result);
                model.Data = datos;

                return model;

            }

            catch (Exception ex)
            {
    
                return model;
            }
        }

        public async Task<Response<SimuladorCuotasConstruccionResponseDto>> GetListConstruccion(SimuladorCuotasConstruccionDto request)
        {
            var model = new Response<SimuladorCuotasConstruccionResponseDto> { Data = new SimuladorCuotasConstruccionResponseDto() };

            try
            {

                var APIURL = ConfigurationManager.AppSettings?["UrlService"]?.ToString();
                var url = $"{APIURL}/api/simuladorcuotasconstruccion";

                HttpClient client = new HttpClient();
                string json = JsonConvert.SerializeObject(request);

                var requestMessage = new HttpRequestMessage();

                requestMessage.Method = new HttpMethod("POST");
                requestMessage.Content = new StringContent(json, Encoding.UTF8, "application/json");
                requestMessage.RequestUri = new Uri(url);

                var httpResponse = await client.SendAsync(requestMessage);
  
                var result = await httpResponse.Content.ReadAsStringAsync();
                var datos = JsonConvert.DeserializeObject<SimuladorCuotasConstruccionResponseDto>(result);
                model.Data = datos;

                return model;

            }

            catch (Exception ex)
            {

                return model;
            }
        }

        public async Task<Response<SimuladorCuotasMejoramientoResponseDto>> GetListMejoramiento(SimuladorCuotasMejoramientoDto request)
        {
            var model = new Response<SimuladorCuotasMejoramientoResponseDto> { Data = new SimuladorCuotasMejoramientoResponseDto() };

            try
            {

                var APIURL = ConfigurationManager.AppSettings?["UrlService"]?.ToString();
                var url = $"{APIURL}/api/simuladorcuotasmejoramiento";

                HttpClient client = new HttpClient();
                string json = JsonConvert.SerializeObject(request);

                var requestMessage = new HttpRequestMessage();
                requestMessage.Method = new HttpMethod("POST");
                requestMessage.Content = new StringContent(json, Encoding.UTF8, "application/json");
                requestMessage.RequestUri = new Uri(url);

                var httpResponse = await client.SendAsync(requestMessage);

                var result = await httpResponse.Content.ReadAsStringAsync();
                var datos = JsonConvert.DeserializeObject<SimuladorCuotasMejoramientoResponseDto>(result);
                model.Data = datos;

                return model;

            }

            catch (Exception ex)
            {
                return model;
            }
        }

        public async Task<Response<List<SimuladorBancosTasasResponseDto>>> GetTasas()
        {
            var model = new Response<List<SimuladorBancosTasasResponseDto>> { Data = new List<SimuladorBancosTasasResponseDto>() };

            try
            {

                var APIURL = ConfigurationManager.AppSettings?["UrlService"]?.ToString();
                var url = $"{APIURL}/api/BancosTasas";

                HttpClient client = new HttpClient();
                string json ="";
                var requestMessage = new HttpRequestMessage();
                requestMessage.Method = new HttpMethod("POST");
                requestMessage.RequestUri = new Uri(url);

                var httpResponse = await client.SendAsync(requestMessage);
                var result = await httpResponse.Content.ReadAsStringAsync();
                var datos = JsonConvert.DeserializeObject< List<SimuladorBancosTasasResponseDto>>(result);
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
