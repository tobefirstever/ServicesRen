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
using Renavi.Infrastructure.Repository.SqlRepository;
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
                config.AddMap(new GerenciaMap());
                config.AddMap(new UbigeoMap());
            });

            #region LogBusqueda

            container.RegisterType<INLogApplication, NLogApplication>();
            container.RegisterType<INLogDomain, NLogDomain>();
            container.RegisterType<INLogRepository, NLogRepository>();

            #endregion

            #region Gerencia
            container.RegisterType<IGerenciaApplication, GerenciaApplication>();
            container.RegisterType<IGerenciaDomain, GerenciaDomain>();
            container.RegisterType<IGerenciaRepository, GerenciaRepository>();
            #endregion

            #region Ubigeo
            container.RegisterType<IUbigeoApplication, UbigeoApplication>();
            container.RegisterType<IUbigeoDomain, UbigeoDomain>();
            container.RegisterType<IUbigeoRepository, UbigeoRepository>();
            #endregion

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
