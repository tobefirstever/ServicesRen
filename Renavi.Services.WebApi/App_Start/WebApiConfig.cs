using Renavi.Services.WebApi.Core;
using Renavi.Transversal.IoC;
using Renavi.Transversal.Mapper;
using System.Web.Http;
using Newtonsoft.Json.Serialization;
using Swashbuckle.Application;
using Renavi.Services.WebApi.Filters;

namespace Renavi.Services.WebApi
{
    public static class WebApiConfig
    {
        /// <summary>
        /// Register
        /// </summary>
        /// <param name="config"></param>
        public static void Register(HttpConfiguration config)
        {
            // Initialize Unity Ioc
            if (config != null)
            {
                config.DependencyResolver = new UnityResolver(UnityResolver.InitializeContainer());

                // Initialize AutoMapper
                Mapping.Inicializate();

                // CamelCase Json
                //var json = config.Formatters.JsonFormatter;
                //json.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

                config.Filters.Add(new ValidateModelAttribute());

                // Enabled Cors
                config.EnableCors();
                config.SetCorsPolicyProviderFactory(new DynamicPolicyProviderFactory());

                // Rutas de API web
                config.MapHttpAttributeRoutes();
                config.MessageHandlers.Add(new TokenValidationHandler());

                config.Routes.MapHttpRoute(
                    name: "swagger_root", 
                    routeTemplate: "", 
                    defaults: null, 
                    constraints: null,
                    handler: new RedirectHandler((message => message.RequestUri.ToString()), "swagger"));

                config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new {id = RouteParameter.Optional});
            }
        }
    }
}
