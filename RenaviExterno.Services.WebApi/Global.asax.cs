using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace RenaviExterno.Services.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_End(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_Error(object sender, EventArgs e)
        {
            var exception = Server.GetLastError();
            //Logger?.Error(exception);
        }

        /// <summary>
        /// </summary>
        protected void Application_Start()
        {
            if (GlobalConfiguration.Configuration != null)
            {
                GlobalConfiguration.Configuration.Formatters?.XmlFormatter?.SupportedMediaTypes?.Clear();
            }
            GlobalConfiguration.Configure(WebApiConfig.Register);


        }
    }
}
