using Dapper.FluentMap;
using Renavi.Application.Interfaces;
using Renavi.Application.Main;
using Renavi.Domain.Entities.Mapping;
using Renavi.Domain.Interfaces;
using Renavi.Domain.Main;
using Renavi.Infrastructure.Configuration;
using Renavi.Infrastructure.Interfaces.Configuration;
using Renavi.Infrastructure.Interfaces.Repository;
using Renavi.Infrastructure.Repository.OracleRepository;
using Renavi.Infrastructure.Repository.UnitOfWork;
using Renavi.Transversal.Common;
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

        public static IUnityContainer InitializeContainer()
        {
            var container = new UnityContainer();
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterSingleton<IConnectionStringProvider, ConnectionStringProvider>();
            container.RegisterType<IConnectionFactory, ConnectionFactory>();

            FluentMapper.Initialize(config =>
            {            
                config.AddMap(new UbigeoMap());
                config.AddMap(new ParametroMap());
                config.AddMap(new ContactoMap());
                config.AddMap(new DireccionMap());
                config.AddMap(new PersonaMap());
            });
       
            #region Entidades tecnicas
            container.RegisterType<IEntidadesTecnicasApplication, EntidadesTecnicasApplication>();
            container.RegisterType<IEntidadesTecnicasDomain, EntidadesTecnicasDomain>();
            container.RegisterType<IEntidadesTecnicasRepository, EntidadesTecnicasRepository>();
            #endregion

            #region General
            container.RegisterType<IGeneralApplication, GeneralApplication>();
            container.RegisterType<IGeneralDomain, GeneralDomain>();
            container.RegisterType<IGeneralRepository, GeneralRepository>();
            #endregion

            #region Oferta inmobiliaria
            container.RegisterType<IOfertaInmobiliariaApplication, OfertaInmobiliariaApplication>();
            container.RegisterType<IOfertaInmobiliariaDomain, OfertaInmobiliariaDomain>();
            container.RegisterType<IOfertaInmobiliariaRepository, OfertaInmobiliariaRepository>();
            #endregion

            #region Precalificacion
            container.RegisterType<IPrecalificacionApplication, PrecalificacionApplication>();
            container.RegisterType<IPrecalificacionDomain, PrecalificacionDomain>();
            container.RegisterType<IPrecalificacionRepository, PrecalificacionRepository>();
            #endregion

            #region Productos
            container.RegisterType<IProductosApplication, ProductosApplication>();
            container.RegisterType<IProductosDomain, ProductosDomain>();
            container.RegisterType<IProductosRepository, ProductosRepository>();
            #endregion

            #region Simulador
            container.RegisterType<ISimuladorCuotasApplication, SimuladorCuotasApplication>();
            container.RegisterType<ISimuladorCuotasDomain, SimuladorCuotasDomain>();
            container.RegisterType<ISimuladorCuotasRepository, SimuladorCuotasRepository>();

            #endregion

            #region Agencia
            container.RegisterType<IAgenciaApplication, AgenciaApplication>();
            container.RegisterType<IAgenciaDomain, AgenciaDomain>();
            container.RegisterType<IAgenciaRepository, AgenciaRepository>();
            #endregion

            #region Ubigeo
            container.RegisterType<IUbigeoApplication, UbigeoApplication>();
            container.RegisterType<IUbigeoDomain, UbigeoDomain>();
            container.RegisterType<IUbigeoRepository, UbigeoRepository>();
            #endregion

            #region Usuarios
            container.RegisterType<IUsuarioApplication, UsuarioApplication>();
            container.RegisterType<IUsuarioDomain, UsuarioDomain>();
            container.RegisterType<IUsuarioRepository, UsuarioRepository>();
            #endregion

            #region Parametro
            container.RegisterType<IParametroApplication, ParametroApplication>();
            container.RegisterType<IParametroDomain, ParametroDomain>();
            container.RegisterType<IParametroRepository, ParametroRepository>();
            #endregion

            #region Metricas
            container.RegisterType<IMetricasApplication, MetricasApplication>();
            container.RegisterType<IMetricasRepository, MetricasRepository>();
            container.RegisterType<IMetricasDomain, MetricasDomain>();
            #endregion


            container.RegisterType<IPerfilApplication, PerfilApplication>();

            container.RegisterType<IDireccionRepository, DireccionRepository>();
            container.RegisterType<IDireccionDomain, DireccionDomain>();


            container.RegisterType<IPersonaRepository, PersonaRepository>();
            container.RegisterType<IPersonaDomain, PersonaDomain>();

            container.RegisterType<IContactoRepository, ContactoRepository>();
            container.RegisterType<IContactoDomain, ContactoDomain>();

            container.RegisterType<IInteraccionApplication, InteraccionApplication>();
            container.RegisterType<IInteraccionRepository, InteraccionRepository>();
            container.RegisterType<IInteraccionDomain, InteraccionDomain>();

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
