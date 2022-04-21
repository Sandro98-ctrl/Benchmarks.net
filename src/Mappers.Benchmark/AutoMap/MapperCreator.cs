using AutoMapper;
using Mappers.Benchmark.AutoMap.Profiles;

namespace Mappers.Benchmark.AutoMap;

public static class MapperCreator
{
    public static IMapper Create()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<UserProfile>();
            cfg.AddProfile<UserSourceProfile>();
            cfg.AddProfile<AddressProfile>();
            cfg.AddProfile<AccountProfile>();
        });

        return config.CreateMapper();
    }
}
