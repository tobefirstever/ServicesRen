using Renavi.Application.Interfaces;
using Renavi.Application.Main;
using Renavi.Domain.Interfaces;
using Renavi.Domain.Main;
using Renavi.Infrastructure.Configuration;
using Renavi.Infrastructure.Interfaces.Configuration;
using Renavi.Infrastructure.Interfaces.Repository;
using Renavi.Infrastructure.Repository.OracleRepository;
using Renavi.Infrastructure.Repository.UnitOfWork;
using Renavi.Infrastructure.Services.Cabiel.Base;
using Renavi.Infrastructure.Services.Cabiel.Contracts;
using Renavi.Infrastructure.Services.Cabiel.Implementations;
using Renavi.Transversal.Common;
using Unity;

namespace Renavi.Transversal.IoC
{
    public static class SetupComponents
    {
        public static void RegisterTransversalDependencies(IUnityContainer container)
        {
            container.RegisterSingleton<IConnectionStringProvider, ConnectionStringProvider>();
            container.RegisterType<IConnectionFactory, ConnectionFactory>();
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterType<ILogger, NLogLogger>();
        }

        public static void RegisterEntidadesTecnicasDependencies(IUnityContainer container)
        {
            container.RegisterType<IEntidadesTecnicasApplication, EntidadesTecnicasApplication>();
            container.RegisterType<IEntidadesTecnicasDomain, EntidadesTecnicasDomain>();
            container.RegisterType<IEntidadesTecnicasRepository, EntidadesTecnicasRepository>();
        }


        public static void RegisterGeneralDependencies(IUnityContainer container)
        {
            container.RegisterType<IGeneralApplication, GeneralApplication>();
            container.RegisterType<IGeneralDomain, GeneralDomain>();
            container.RegisterType<IGeneralRepository, GeneralRepository>();
        }


        public static void RegisterOfertaInmobiliariaDependencies(IUnityContainer container)
        {
            container.RegisterType<IOfertaInmobiliariaApplication, OfertaInmobiliariaApplication>();
            container.RegisterType<IOfertaInmobiliariaDomain, OfertaInmobiliariaDomain>();
            container.RegisterType<IOfertaInmobiliariaRepository, OfertaInmobiliariaRepository>();
        }


        public static void RegisterParametroDependencies(IUnityContainer container)
        {
            container.RegisterType<IParametroApplication, ParametroApplication>();
            container.RegisterType<IParametroDomain, ParametroDomain>();
            container.RegisterType<IParametroRepository, ParametroRepository>();
        }


        public static void RegisterPreCalificacionDependencies(IUnityContainer container)
        {
            container.RegisterType<IPrecalificacionApplication, PrecalificacionApplication>();
            container.RegisterType<IPrecalificacionDomain, PrecalificacionDomain>();
            container.RegisterType<IPrecalificacionRepository, PrecalificacionRepository>();
        }

        public static void RegisterProductosDependencies(IUnityContainer container)
        {
            container.RegisterType<IProductosApplication, ProductosApplication>();
            container.RegisterType<IProductosDomain, ProductosDomain>();
            container.RegisterType<IProductosRepository, ProductosRepository>();
        }


        public static void RegisterSimuladorDependencies(IUnityContainer container)
        {
            container.RegisterType<ISimuladorCuotasApplication, SimuladorCuotasApplication>();
            container.RegisterType<ISimuladorCuotasDomain, SimuladorCuotasDomain>();
            container.RegisterType<ISimuladorCuotasRepository, SimuladorCuotasRepository>();
        }

        public static void RegisterUbigeoDependencies(IUnityContainer container)
        {
            container.RegisterType<IUbigeoApplication, UbigeoApplication>();
            container.RegisterType<IUbigeoDomain, UbigeoDomain>();
            container.RegisterType<IUbigeoRepository, UbigeoRepository>();
        }

        public static void RegisterUsuarioDependencies(IUnityContainer container)
        {
            container.RegisterType<IUsuarioApplication, UsuarioApplication>();
            container.RegisterType<IUsuarioDomain, UsuarioDomain>();
            container.RegisterType<IUsuarioRepository, UsuarioRepository>();
        }

        public static void RegisterContactoDependencies(IUnityContainer container)
        {
            container.RegisterType<IContactoRepository, ContactoRepository>();
            container.RegisterType<IContactoDomain, ContactoDomain>();
        }

        public static void RegisterPersonaDependencies(IUnityContainer container)
        {
            container.RegisterType<IPersonaRepository, PersonaRepository>();
            container.RegisterType<IPersonaDomain, PersonaDomain>();
        }

        public static void RegisterPerfilDependencies(IUnityContainer container)
        {
            container.RegisterType<IPerfilApplication, PerfilApplication>();
        }

        public static void RegisterDireccionDependencies(IUnityContainer container)
        {
            container.RegisterType<IDireccionRepository, DireccionRepository>();
            container.RegisterType<IDireccionDomain, DireccionDomain>();
        }

        public static void RegisterExternalServices(IUnityContainer container)
        {
            container.RegisterType<IClientCabiel, ClientCabiel>();
            container.RegisterType<IExternalServiceCabiel, ExternalServiceCabiel>();
        }
    }
}
