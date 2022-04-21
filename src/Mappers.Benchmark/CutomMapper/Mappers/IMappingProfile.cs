namespace Mappers.Benchmark.CutomMapper.Mappers;

public interface IMappingProfile<TSource, TDestination>
{
    TDestination Map(TSource source);
}