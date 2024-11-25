using Renavi.Services.WebApi.Core;
using Renavi.Transversal.IoC;
using Renavi.Transversal.Mapper;
using System.Web.Http;
using Newtonsoft.Json.Serialization;
using Swashbuckle.Application;
using Renavi.Services.WebApi.Filters;
using Renavi.Services.WebApi.Middlewares;
using System.Net.Http;
using Unity;
using System;
using Renavi.Services.WebApi.Controllers;

namespace Renavi.Services.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            if (config == null)
                throw new ArgumentNullException(nameof(config), "La configuración de HttpConfiguration no puede ser nula.");



            var container = UnityResolver.InitializeContainer();
            ApiDependencyResolver.RegisterApiDependencies(container);
            config.DependencyResolver = new UnityResolver(container);
            var controller = container.Resolve<PerfilController>();
            Console.WriteLine(controller != null ? "Resolución exitosa" : "Error al resolver PerfilController");
            config.MessageHandlers.Add((DelegatingHandler)config.DependencyResolver.GetService(typeof(ExceptionMiddleware)));
            config.Filters.Add(new ValidateModelAttribute());


            config.EnableCors();
            config.SetCorsPolicyProviderFactory(new DynamicPolicyProviderFactory());

            Mapping.Inicializate();

       

            // Rutas de API web
            RegisterRoutes(config);
            config.MessageHandlers.Add(new TokenValidationHandler());

        }

        private static void RegisterRoutes(HttpConfiguration config)
        {
            // Rutas de Swagger
            config.Routes.MapHttpRoute(
                name: "swagger_root",
                routeTemplate: "",
                defaults: null,
                constraints: null,
                handler: new RedirectHandler((message => message.RequestUri.ToString()), "swagger")
            );

            // Rutas de la API principal
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
