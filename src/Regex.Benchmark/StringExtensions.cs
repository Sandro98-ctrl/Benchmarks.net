namespace Regex.Benchmark;

public static class StringExtensions
{
    public static string OnlyNumbersRegex(this string source) =>
        System.Text.RegularExpressions.Regex.Replace(source, "[^0-9]", string.Empty);

    public static string OnlyNumbersLinq(this string source) =>
        string.Join(string.Empty, source.Where(c => char.IsDigit(c)));
}
