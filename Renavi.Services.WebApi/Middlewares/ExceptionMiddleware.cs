using Renavi.Transversal.Common;
using System;
using System.Net;
using System.Net.Http;
using System.ServiceModel;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace Renavi.Services.WebApi.Middlewares
{
    public class ExceptionMiddleware : DelegatingHandler
    {

        private readonly ILogger _logger;

        public ExceptionMiddleware(ILogger logger)
        {
            _logger = logger;
        }



        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            try
            {
                return await base.SendAsync(request, cancellationToken);
            }
            catch (FaultException ex)
            {
                return HandleException(HttpStatusCode.InternalServerError, "Ocurrió un error en el servidor.", ex);
            }
            catch (InvalidOperationException ex)
            {
                return HandleException(HttpStatusCode.BadRequest, "Operación inválida.", ex);
            }
            catch (ArgumentNullException ex)
            {
                return HandleException(HttpStatusCode.NotFound, "Recurso no encontrado.", ex);
            }
            catch (Exception ex)
            {
                return HandleException(HttpStatusCode.InternalServerError, "Ocurrió un error inesperado.", ex);
            }
        }


       

        private HttpResponseMessage HandleException(HttpStatusCode statusCode, string message, Exception ex)
        {
           
            var errorId = Guid.NewGuid().ToString();

            _logger.Error("Ocurrio un error ." + errorId, ex);

            var response = new GeneralResponse
            {
                Success =false,
                Message = message,
                Data = errorId
            };


            return new HttpResponseMessage(statusCode)
            {
                Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(response)),
                ReasonPhrase = message
            };
        }
    }
}