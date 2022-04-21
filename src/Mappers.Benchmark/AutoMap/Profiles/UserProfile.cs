using AutoMapper;
using Mappers.Benchmark.Dtos;
using Mappers.Benchmark.Entities;

namespace Mappers.Benchmark.AutoMap.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserDto, User>()
            .ReverseMap();
    }
}
