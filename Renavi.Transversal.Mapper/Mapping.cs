using Renavi.Transversal.Mapper.Profile;

namespace Renavi.Transversal.Mapper
{
    public static class Mapping
    {
        public static void Inicializate()
        {
            AutoMapper.Mapper.Initialize(x =>
            {
                x?.AddProfile<UbigeoProfile>();
                x?.AddProfile<ParametroProfile>();
                x?.AddProfile<EntidadTecnicaProfile>();
            });
        }

        public static TDestino Map<TSource, TDestino>(TSource source, TDestino destino)
        {
            return AutoMapper.Mapper.Map(source, destino);
        }

        public static TDestino Map<TSource, TDestino>(TSource source)
        {
            return AutoMapper.Mapper.Map<TSource, TDestino>(source);
        }
    }
}
