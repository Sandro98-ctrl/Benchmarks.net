using AutoMapper;
using Mappers.Benchmark.Dtos;
using Mappers.Benchmark.Entities;

namespace Mappers.Benchmark.AutoMap.Profiles;

public class AccountProfile : Profile
{
    public AccountProfile()
    {
        CreateMap<AccountDto, Account>()
            .ReverseMap();
    }
}
