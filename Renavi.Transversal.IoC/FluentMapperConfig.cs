using Dapper.FluentMap;
using Renavi.Domain.Entities.Mapping;


namespace Renavi.Transversal.IoC
{
    public static class FluentMapperConfig
    {
        public static void InitializeMappings()
        {
            FluentMapper.Initialize(config =>
            {
                config.AddMap(new UbigeoMap());
                config.AddMap(new ParametroMap());
                config.AddMap(new ContactoMap());
                config.AddMap(new DireccionMap());
                config.AddMap(new PersonaMap());
            });
        }
    }

}
