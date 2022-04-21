using AutoMapper;
using Mappers.Benchmark.Dtos;
using Mappers.Benchmark.Entities;

namespace Mappers.Benchmark.AutoMap.Profiles;

public class UserSourceProfile : Profile
{
    public UserSourceProfile()
    {
        CreateMap<UserSourceDto, UserSource>()
            .ReverseMap();
    }
}
