using Mappers.Benchmark.CutomMapper.Mappers;
using Mappers.Benchmark.Dtos;
using Mappers.Benchmark.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace Mappers.Benchmark.CutomMapper;

public static class CustomMapperCreator
{
    public static CustomMapper Create()
    {
        var services = new ServiceCollection();

        services.AddTransient<IMappingProfile<UserDto, User>, UserMapper>();
        services.AddTransient<IMappingProfile<User, UserDto>, UserMapper>();

        return new(services.BuildServiceProvider());
    }
}
