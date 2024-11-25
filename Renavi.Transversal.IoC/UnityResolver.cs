using Dapper.FluentMap;
using Renavi.Domain.Entities.Mapping;
using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using Unity;


namespace Renavi.Transversal.IoC
{
    public sealed class UnityResolver : IDependencyResolver
    {
        private readonly IUnityContainer _container;

        public UnityResolver(IUnityContainer container)
        {
            if (container == null)
                throw new ArgumentNullException(nameof(container));

            _container = container;
        }

        public static IUnityContainer InitializeContainer(IUnityContainer existingContainer = null)
        {
            var container = existingContainer ?? new UnityContainer();
            Startup.RegisterSoapClient(container, "soap1");
            SetupComponents.RegisterTransversalDependencies(container);
            SetupComponents.RegisterEntidadesTecnicasDependencies(container);
            SetupComponents.RegisterGeneralDependencies(container);
            SetupComponents.RegisterOfertaInmobiliariaDependencies(container);
            SetupComponents.RegisterParametroDependencies(container);
            SetupComponents.RegisterPreCalificacionDependencies(container);
            SetupComponents.RegisterProductosDependencies(container);
            SetupComponents.RegisterSimuladorDependencies(container);
            SetupComponents.RegisterUbigeoDependencies(container);
            SetupComponents.RegisterUsuarioDependencies(container);
            SetupComponents.RegisterContactoDependencies(container);
            SetupComponents.RegisterPersonaDependencies(container);
            SetupComponents.RegisterDireccionDependencies(container);
            SetupComponents.RegisterPerfilDependencies(container);
            SetupComponents.RegisterExternalServices(container);
            FluentMapperConfig.InitializeMappings();

            return container;
        }


        public IDependencyScope BeginScope()
        {
            var child = _container.CreateChildContainer();
            return new UnityResolver(child);
        }

        public void Dispose()
        {
            _container.Dispose(); // Liberar recursos del contenedor
            GC.SuppressFinalize(this);
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return _container.Resolve(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return _container.ResolveAll(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return new List<object>();
            }
        }
    }
}
