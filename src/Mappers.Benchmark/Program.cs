#if !DEBUG

using BenchmarkDotNet.Running;
using Mappers.Benchmark;

BenchmarkRunner.Run<MapperBenchmark>();

#else

using Mappers.Benchmark;
using Mappers.Benchmark.AutoMap;
using Mappers.Benchmark.CutomMapper;
using Mappers.Benchmark.Dtos;
using Mappers.Benchmark.Entities;

var customMapper = CustomMapperCreator.Create();
var autoMapper = MapperCreator.Create();

#region UserDTO

UserDto userDto = UserGenerator.GenerateDto();

Console.WriteLine("DTO FirstName: " + userDto.FirstName);
Console.WriteLine("DTO LastName: " + userDto.LastName);

User user1 = customMapper.Map<UserDto, User>(userDto);

Console.WriteLine("CustomMapper FirstName: " + user1.FirstName);
Console.WriteLine("CustomMapper LastName: " + user1.LastName);

User user2 = autoMapper.Map<User>(userDto);

Console.WriteLine("AutoMapper FirstName: " + user2.FirstName);
Console.WriteLine("AutoMapper LastName: " + user2.LastName);

#endregion UserDTO

Console.WriteLine("==============");

#region User

User user = UserGenerator.Generate();

Console.WriteLine("FirstName: " + user.FirstName);
Console.WriteLine("LastName: " + user.LastName);

UserDto userDto1 = customMapper.Map<User, UserDto>(user);

Console.WriteLine("CustomMapper DTO FirstName: " + userDto1.FirstName);
Console.WriteLine("CustomMapper DTO LastName: " + userDto1.LastName);

UserDto userDto2 = autoMapper.Map<UserDto>(user);

Console.WriteLine("AutoMapper DTO FirstName: " + userDto2.FirstName);
Console.WriteLine("AutoMapper DTO LastName: " + userDto2.LastName);

#endregion User

#endif
