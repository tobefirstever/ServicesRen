
using RenaviExterno.Application;
using RenaviExterno.Application.Interfaces;
using RenaviExterno.Application.Main;
using RenaviExterno.Services;
using RenaviExterno.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using Unity;


namespace RenaviExterno.Transversal.IoC
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

        public static IUnityContainer InitializeContainer()
        {
            var container = new UnityContainer();

   


            container.RegisterType<ISimuladorCuotasApplication,SimuladorCuotasApplication>();
            container.RegisterType<ISimuladorCuotasService,SimuladorCuotasService>();

            container.RegisterType<IAgenciaApplication, AgenciaApplication>();
            container.RegisterType<IAgenciaService, AgenciaService>();


            container.RegisterType<IMetricasApplication, MetricasApplication>();
            container.RegisterType<IMetricasService, MetricasService>();


            container.RegisterType<IOfertaInmobiliariaApplication, OfertaInmobiliariaApplication>();
            container.RegisterType<IOfertaInmobiliariaervice, OfertaInmobiliariaervice>();

            container.RegisterType<IProductosApplication, ProductosApplication>();
            container.RegisterType<IProductoService, ProductoService>();

            container.RegisterType<IUbigeoApplication, UbigeoApplication>();
            container.RegisterType<IUbigeoService, UbigeoService>();

            container.RegisterType<IVideosApplication, VideosApplication>();
            container.RegisterType<IVideosService, VideosService>();

            container.RegisterType<IEntidadesTecnicasApplication, EntidadesTecnicasApplication>();
            container.RegisterType<IEntidadesTecnicasService, EntidadesTecnicasService>();

            container.RegisterType<IParametroApplication, ParametroApplication>();
            container.RegisterType<IParametroService, ParametroService>();

            container.RegisterType<IPerfilApplication, PerfilApplication>();
            container.RegisterType<IPerfilService, PerfilService>();

            container.RegisterType<IUsuarioApplication, UsuarioApplication>();
            container.RegisterType<IUsuarioService, UsuarioService>();

            container.RegisterType<IInteraccionApplication, InteraccionApplication>();
            container.RegisterType<IInteraccionService, InteraccionService>();

            container.RegisterType<IPrecalificacionApplication, PrecalificacionApplication>();
            container.RegisterType<IPrecalificacionService, PrecalificacionService>();

            return container;
        }


        public IDependencyScope BeginScope()
        {
            var child = _container.CreateChildContainer();
            return new UnityResolver(child);
        }

        public void Dispose()
        {
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
