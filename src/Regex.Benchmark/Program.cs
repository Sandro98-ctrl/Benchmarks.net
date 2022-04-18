#if !DEBUG

using BenchmarkDotNet.Running;
using Regex.Benchmark;

BenchmarkRunner.Run<RegexBenchmark>();

#else

using Regex.Benchmark;

var cnpj = "24.864.806/0001-96";

Console.WriteLine(cnpj);

var cnpjOnlyNumbersRegex = cnpj.OnlyNumbersRegex();
var cnpjOnlyNumbersLinq = cnpj.OnlyNumbersLinq();

Console.WriteLine($"Regex: {cnpjOnlyNumbersRegex}");
Console.WriteLine($"Linq:  {cnpjOnlyNumbersLinq}");

#endif