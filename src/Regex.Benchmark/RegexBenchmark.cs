using BenchmarkDotNet.Attributes;

namespace Regex.Benchmark;

[MemoryDiagnoser(false)]
public class RegexBenchmark
{
    private static readonly string Value = "24.864.806/0001-96";

    [Benchmark]
    public string OnlyNumbersRegexExtensions()
    {
        return Value.OnlyNumbersRegex();
    }

    [Benchmark]
    public string OnlyNumbersLinqExtension()
    {
        return Value.OnlyNumbersLinq();
    }
}
