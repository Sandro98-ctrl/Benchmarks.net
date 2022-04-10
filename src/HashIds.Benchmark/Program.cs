#if !DEBUG

using BenchmarkDotNet.Running;
using HashIds.Benchmark;

BenchmarkRunner.Run<HashIdBenchmark>();

#else

using HashidsNet;

var hashIds = new Hashids("XC@s*mg9GBHA", 11);

var firstId = hashIds.Encode(1);
var secondIds = hashIds.Encode(2, 3);

Console.WriteLine(firstId);
Console.WriteLine(secondIds);

var firstRawId = hashIds.Decode("KpbonNyVje7");
var firstRawSingleId = hashIds.DecodeSingle("KpbonNyVje7");
var secondRawIds = hashIds.Decode("EdxZW1H8V1A");

Console.WriteLine(firstRawId[0]);
Console.WriteLine(firstRawSingleId);
Console.WriteLine(string.Join(", ", secondRawIds));

#endif
