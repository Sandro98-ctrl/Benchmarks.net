namespace Mappers.Benchmark.Dtos;

public class UserDto
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public byte Age { get; set; }
    public UserSourceDto Source { get; set; } = null!;
    public string? ImageData { get; set; }
    public int[]? LuckyNumbers { get; set; }
    public decimal Total { get; set; }
    public IEnumerable<AccountDto> Accounts { get; set; } = null!;
    public AddressDto Address { get; set; } = null!;
    public long UnitId { get; set; }
    public string? UnitName { get; set; }
}
