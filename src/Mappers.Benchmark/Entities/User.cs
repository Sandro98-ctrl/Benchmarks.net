namespace Mappers.Benchmark.Entities;

public class User
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public byte Age { get; set; }
    public UserSource Source { get; set; } = null!;
    public string? ImageData { get; set; }
    public int[]? LuckyNumbers { get; set; }
    public decimal Total { get; set; }
    public IEnumerable<Account> Accounts { get; set; } = null!;
    public Address Address { get; set; } = null!;
    public long UnitId { get; set; }
    public string? UnitName { get; set; }
}
