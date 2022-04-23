using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using Mappers.Benchmark.AutoMap;
using Mappers.Benchmark.CutomMapper;
using Mappers.Benchmark.CutomMapper.Mappers;
using Mappers.Benchmark.Dtos;
using Mappers.Benchmark.Entities;

namespace Mappers.Benchmark;

[RankColumn, MemoryDiagnoser(false)]
public class MapperBenchmark
{
    private static readonly AutoMapper.IMapper _autoMapper = MapperCreator.Create();
    private static readonly IMapper _customMapper = CustomMapperCreator.Create();
    private static readonly UserMapper _userMapper = new();

    private static readonly UserDto UserDto = UserGenerator.GenerateDto();
    private static readonly User User = UserGenerator.Generate();

    private readonly Consumer consumer = new();

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
    public List<User> AutoMapperArrayToList()
    {
        User[] users = { User, User, User };
        UserDto[] userDtos = { UserDto, UserDto, UserDto };

        _ = _autoMapper.Map<User[], List<UserDto>>(users);
        return _autoMapper.Map<UserDto[], List<User>>(userDtos);
    }

    [Benchmark]
    public List<User> AutoMapperListToList()
    {
        var users = new List<User> { User, User, User };
        var userDtos= new List<UserDto> { UserDto, UserDto, UserDto };

        _ = _autoMapper.Map<List<User>, List<UserDto>>(users);
        return _autoMapper.Map<List<UserDto>, List<User>>(userDtos);
    }

    [Benchmark]
    public User[] AutoMapperArrayToArray()
    {
        User[] users = { User, User, User };
        UserDto[] userDtos = { UserDto, UserDto, UserDto };

        _ = _autoMapper.Map<User[], UserDto[]>(users);
        return _autoMapper.Map<UserDto[], User[]>(userDtos);
    }

    [Benchmark]
    public User[] AutoMapperListToArray()
    {
        var users = new List<User> { User, User, User };
        var userDtos = new List<UserDto> { UserDto, UserDto, UserDto };

        _ = _autoMapper.Map<List<User>, UserDto[]>(users);
        return _autoMapper.Map<List<UserDto>, User[]>(userDtos);
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
    public List<User> CustomMapperListToList()
    {
        var users = new List<User> { User, User, User };
        var userDtos = new List<UserDto> { UserDto, UserDto, UserDto };

        _ = _customMapper.MapToList<User, UserDto>(users);
        return _customMapper.MapToList<UserDto, User>(userDtos);
    }

    [Benchmark]
    public void CustomMapperListToEnumerable()
    {
        var users = new List<User> { User, User, User };
        var userDtos = new List<UserDto> { UserDto, UserDto, UserDto };

        _customMapper.Map<User, UserDto>(users).Consume(consumer);
        _customMapper.Map<UserDto, User>(userDtos).Consume(consumer);
    }

    [Benchmark]
    public void CustomMapperArrayToEnumerable()
    {
        User[] users = { User, User, User };
        UserDto[] userDtos = { UserDto, UserDto, UserDto };

        _customMapper.Map<User, UserDto>(users).Consume(consumer);
        _customMapper.Map<UserDto, User>(userDtos).Consume(consumer);
    }

    [Benchmark]
    public List<User> CustomMapperArrayToList()
    {
        User[] users = { User, User, User };
        UserDto[] userDtos = { UserDto, UserDto, UserDto };

        _ = _customMapper.MapToList<User, UserDto>(users);
        return _customMapper.MapToList<UserDto, User>(userDtos);
    }

    [Benchmark]
    public User[] CustomMapperListToArray()
    {
        var users = new List<User> { User, User, User };
        var userDtos = new List<UserDto> { UserDto, UserDto, UserDto };

        _ = _customMapper.MapToArray<User, UserDto>(users);
        return _customMapper.MapToArray<UserDto, User>(userDtos);
    }

    [Benchmark]
    public User[] CustomMapperArrayToArray()
    {
        User[] users = { User, User, User };
        UserDto[] userDtos = { UserDto, UserDto, UserDto };

        _ = _customMapper.MapToArray<User, UserDto>(users);
        return _customMapper.MapToArray<UserDto, User>(userDtos);
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

    [Benchmark]
    public List<User> UserMapperList()
    {
        _ = Enumerable.Select(new[] { User, User, User }, _userMapper.Map).ToList();
        return Enumerable.Select(new[] { UserDto, UserDto, UserDto }, _userMapper.Map).ToList();
    }
}
