using RenaviExterno.Transversal.IoC;
using Renavi.Transversal.Mapper;
using RenaviExterno.Services.WebApi.Core;
using RenaviExterno.Services.WebApi.Filters;
using Swashbuckle.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web;

namespace RenaviExterno.Services.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Initialize Unity Ioc
            if (config != null)
            {
                config.DependencyResolver = new UnityResolver(UnityResolver.InitializeContainer());

                //Initialize AutoMapper
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


                config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new { id = RouteParameter.Optional });
            }
        }
    }
}
