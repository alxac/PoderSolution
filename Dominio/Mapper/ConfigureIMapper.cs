using AutoMapper;

namespace Dominio.Mapper
{
    public class ConfigureIMapper
    {
        public static IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new EntityToDtoProfile());
            });
            return config.CreateMapper();
        }
    }

    public class AutoMapperFixture : ConfigureIMapper, IDisposable
    {
        public void Dispose() { }
    }
}
