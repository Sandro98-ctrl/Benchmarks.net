using BenchmarkDotNet.Attributes;

namespace Regex.Benchmark;

[MemoryDiagnoser(false)]
public class RegexBenchmark
{
    private static readonly string Value = "24.864.806/0001-96";

    [Benchmark]
    public string OnlyNumbersRegex()
    {
        return Value.OnlyNumbersRegex();
    }

    [Benchmark]
    public string OnlyNumbersLinq()
    {
        return Value.OnlyNumbersLinq();
    }
}
