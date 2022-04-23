namespace Mappers.Benchmark.CutomMapper;

public interface IMapper
{
    TDestination Map<TSource, TDestination>(TSource source);
    IEnumerable<TDestination> Map<TSource, TDestination>(IEnumerable<TSource> source);
    List<TDestination> MapToList<TSource, TDestination>(IEnumerable<TSource> source);
    TDestination[] MapToArray<TSource, TDestination>(IEnumerable<TSource> source);
    TDestination Map<TDestination>(object source);
    TDestination MapUsingReflection<TSource, TDestination>(TSource source);
}
