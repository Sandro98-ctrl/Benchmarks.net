using Mappers.Benchmark.Dtos;
using Mappers.Benchmark.Entities;

namespace Mappers.Benchmark;

public static class UserGenerator
{
    public static User Generate()
    {
        return new()
        {
            FirstName = "Henry",
            LastName = "Mueller",
            Age = 46,
            Source = new()
            {
                Name = "Anything",
                Provider = new object()
            },
            ImageData = "/photo/profile/henry.png",
            LuckyNumbers = new[] { 93, 1, 237, 29 },
            Total = 102.66M,
            Accounts = new Account[]
            {
                new() { BankName = "Ailos", Number = 634 },
                new() { BankName = "Dotz", Number = 493 },
                new() { BankName = "Nubank", Number = 299 }
            },
            Address = new()
            {
                City = "San Francisco",
                ZipCode = "4328794",
                Street = "San Francisco Street",
                FlatNo = true,
                BuildingNo = false,
            },
            UnitId = 23,
            UnitName = "Whatever"
        };
    }

    public static UserDto GenerateDto()
    {
        return new()
        {
            FirstName = "Thomas",
            LastName = "Evans",
            Age = 31,
            Source = new()
            {
                Name = "Nothing",
                Provider = new object()
            },
            ImageData = "/photo/profile/thomas.png",
            LuckyNumbers = new[] { 13, 54, 2, 12 },
            Total = 34.56M,
            Accounts = new AccountDto[]
            {
                new() { BankName = "Itaú", Number = 123 },
                new() { BankName = "Bradesco", Number = 456 },
                new() { BankName = "Santander", Number = 789 }
            },
            Address = new()
            {
                City = "Orlando",
                ZipCode = "32789",
                Street = "Winter Park",
                FlatNo = false,
                BuildingNo = true,
            },
            UnitId = 43,
            UnitName = "Hoola Momba"
        };
    }
}
