using BenchmarkDotNet.Attributes;
using HashidsNet;

namespace HashIds.Benchmark;

[MemoryDiagnoser(false)]
public class HashIdBenchmark
{
    private static readonly Hashids HashIds = new("XC@s*mg9GBHA", 11);

    [Benchmark]
    public int IntFromHashArray()
    {
        return HashIds.Decode("KpbonNyVje7")[0];
    }

    [Benchmark]
    public int IntFromHashSingle()
    {
        return HashIds.DecodeSingle("KpbonNyVje7");
    }

    [Benchmark]
    public string HashFromInt()
    {
        return HashIds.Encode(1);
    }
}
