
using Renavi.Services.WebApi.Middlewares;
using System;
using System.Net.Http;
using Unity;

namespace Renavi.Services.WebApi.Core
{
    public static class ApiDependencyResolver
    {
        public static void RegisterApiDependencies(IUnityContainer container)
        {
            if (container == null)
                throw new ArgumentNullException(nameof(container));

            container.RegisterType<DelegatingHandler, ExceptionMiddleware>("ExceptionMiddleware");
        }
    }
}