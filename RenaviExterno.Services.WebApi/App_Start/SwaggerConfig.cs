using System.Web.Http;
using WebActivatorEx;
using RenaviExterno.Services.WebApi;
using Swashbuckle.Application;
using System;
using System.Reflection;
using System.IO;
using System.Configuration;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace RenaviExterno.Services.WebApi
{
    public static class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            string setting = ConfigurationManager.AppSettings["EnableSwaggerPage"];

            // Only enable the Swagger page is the webconfig setting explicitly enables it
            if (string.IsNullOrWhiteSpace(setting) || !bool.TryParse(setting, out bool enableSwaggerPage) || !enableSwaggerPage)
            {
                return;
            }

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                {
                    var baseDirectory = AppDomain.CurrentDomain.BaseDirectory + @"\bin\";
                    var commentsFileName = Assembly.GetExecutingAssembly().GetName().Name + ".xml";
                    var commentsFile = Path.Combine(baseDirectory, commentsFileName);
                    string url = "http://www.renavi.com.pe/";

                    c?.SingleApiVersion("v1", "API RenaviExterno")
                        ?.Description("API RenaviExterno")
                        ?.TermsOfService("Nuestro servicio se encuentra disponible 24x7")
                        ?.Contact(cc => cc?.Name("Team Renavi")
                            ?.Url(url + "Contactanos")
                            ?.Email("aplicaciones@mivivienda.com.pe"))
                        ?.License(lc => lc?.Name("Uso autorizado para las aplicaciones de Fondo mi vivienda")
                            ?.Url(url + "Transparencia"));
                    c?.ApiKey("apiKey")
                        ?.Description("API Key Authentication")
                        ?.Name("Authorization")
                        ?.In("header");
                    c?.IncludeXmlComments(commentsFile);
                })
                ?.EnableSwaggerUi(c => { c?.InjectJavaScript(thisAssembly, "RenaviExterno.Services.WebApi.CustomContent.api-key-header-auth.js"); });

        }
    }
}
