using NLog;
using System;
using System.Web;
using System.Web.Http;

namespace Renavi.Services.WebApi
{

    public class WebApiApplication : HttpApplication
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();


        protected void Application_Start()
        {

            Logger.Info("La aplicación ha iniciado.");

            if (GlobalConfiguration.Configuration != null)
            {
                GlobalConfiguration.Configuration.Formatters?.XmlFormatter?.SupportedMediaTypes?.Clear();
            }
            GlobalConfiguration.Configure(WebApiConfig.Register);


        }
    }
}
