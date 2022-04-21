using Mappers.Benchmark.Dtos;
using Mappers.Benchmark.Entities;

namespace Mappers.Benchmark.CutomMapper.Mappers;

public class UserMapper : 
    IMappingProfile<UserDto, User>, 
    IMappingProfile<User, UserDto>
{
    public User Map(UserDto source)
    {
        return new User
        {
            FirstName = source.FirstName,
            LastName = source.LastName,
            Age = source.Age,
            Source = new UserSource
            {
                Name = source.Source.Name,
                Provider = source.Source.Provider
            },
            ImageData = source.ImageData,
            LuckyNumbers = source.LuckyNumbers,
            Total = source.Total,
            Accounts = source.Accounts.Select(sourceAccount => new Account
            {
                BankName = sourceAccount.BankName,
                Number = sourceAccount.Number
            }),
            Address = new Address
            {
                City = source.Address.City,
                ZipCode = source.Address.ZipCode,
                Street = source.Address.Street,
                FlatNo = source.Address.FlatNo,
                BuildingNo = source.Address.BuildingNo
            },
            UnitId = source.UnitId,
            UnitName = source.UnitName
        };
    }

    public UserDto Map(User source)
    {
        return new UserDto
        {
            FirstName = source.FirstName,
            LastName = source.LastName,
            Age = source.Age,
            Source = new UserSourceDto
            {
                Name = source.Source.Name,
                Provider = source.Source.Provider
            },
            ImageData = source.ImageData,
            LuckyNumbers = source.LuckyNumbers,
            Total = source.Total,
            Accounts = source.Accounts.Select(sourceAccount => new AccountDto
            {
                BankName = sourceAccount.BankName,
                Number = sourceAccount.Number
            }),
            Address = new AddressDto
            {
                City = source.Address.City,
                ZipCode = source.Address.ZipCode,
                Street = source.Address.Street,
                FlatNo = source.Address.FlatNo,
                BuildingNo = source.Address.BuildingNo
            },
            UnitId = source.UnitId,
            UnitName = source.UnitName
        };
    }
}
