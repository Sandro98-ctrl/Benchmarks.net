namespace Mappers.Benchmark.CutomMapper;

public interface IMapper
{
    TDestination Map<TSource, TDestination>(TSource source);
    TDestination Map<TDestination>(object source);
    TDestination MapUsingReflection<TSource, TDestination>(TSource source);
}
