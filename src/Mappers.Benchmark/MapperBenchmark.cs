using BenchmarkDotNet.Attributes;
using Mappers.Benchmark.AutoMap;
using Mappers.Benchmark.CutomMapper;
using Mappers.Benchmark.CutomMapper.Mappers;
using Mappers.Benchmark.Dtos;
using Mappers.Benchmark.Entities;

namespace Mappers.Benchmark;

[MemoryDiagnoser(false)]
public class MapperBenchmark
{
    private static readonly AutoMapper.IMapper _autoMapper = MapperCreator.Create();
    private static readonly IMapper _customMapper = CustomMapperCreator.Create();
    private static readonly UserMapper _userMapper = new();

    private static readonly UserDto UserDto = UserGenerator.GenerateDto();
    private static readonly User User = UserGenerator.Generate();

    [Benchmark]
    public User AutoMapperObject()
    {
        _ = _autoMapper.Map<UserDto>(User);
        return _autoMapper.Map<User>(UserDto);
    }

    [Benchmark]
    public User AutoMapperGenerics()
    {
        _ = _autoMapper.Map<User, UserDto>(User);
        return _autoMapper.Map<UserDto, User>(UserDto);
    }

    [Benchmark]
    public User CustomMapperObject()
    {
        _ = _customMapper.Map<UserDto>(User);
        return _customMapper.Map<User>(UserDto);
    }

    [Benchmark]
    public User CustomMapperGenerics()
    {
        _ = _customMapper.Map<User, UserDto>(User);
        return _customMapper.Map<UserDto, User>(UserDto);
    }

    [Benchmark]
    public User CustomMapperReflection()
    {
        _ = _customMapper.MapUsingReflection<User, UserDto>(User);
        return _customMapper.MapUsingReflection<UserDto, User>(UserDto);
    }

    [Benchmark]
    public User UserMapper()
    {
        _ = _userMapper.Map(User);
        return _userMapper.Map(UserDto);
    }
}
