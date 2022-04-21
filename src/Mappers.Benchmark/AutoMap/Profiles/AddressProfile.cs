using AutoMapper;
using Mappers.Benchmark.Dtos;
using Mappers.Benchmark.Entities;

namespace Mappers.Benchmark.AutoMap.Profiles;

public class AddressProfile : Profile
{
    public AddressProfile()
    {
        CreateMap<AddressDto, Address>()
            .ReverseMap();
    }
}
