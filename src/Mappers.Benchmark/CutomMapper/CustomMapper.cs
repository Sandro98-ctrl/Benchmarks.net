using Mappers.Benchmark.CutomMapper.Mappers;

namespace Mappers.Benchmark.CutomMapper;

public class CustomMapper : IMapper
{
    private readonly IServiceProvider _serviceProvider;

    public CustomMapper(IServiceProvider serviceProvider) =>
        _serviceProvider = serviceProvider;

    public TDestination Map<TSource, TDestination>(TSource source)
    {
        var interfaceType = typeof(IMappingProfile<TSource, TDestination>);

        if (_serviceProvider.GetService(interfaceType) is not IMappingProfile<TSource, TDestination> type)
            throw new NotImplementedException($"Can not found the mapper for the types Source: {typeof(TSource)} || Destination: {typeof(TDestination)}");

        return type.Map(source);
    }

    public TDestination MapUsingReflection<TSource, TDestination>(TSource source)
    {
        var interfaceType = typeof(IMappingProfile<TSource, TDestination>);

        var type = interfaceType.Assembly
            .ExportedTypes
            .SingleOrDefault(x => x.IsClass && !x.IsAbstract && interfaceType.IsAssignableFrom(x));

        if (type is null)
            throw new NotImplementedException($"Can not found the mapper for the types Source: {typeof(TSource)} || Destination: {typeof(TDestination)}");

        var instance = (IMappingProfile<TSource, TDestination>)Activator.CreateInstance(type)!;

        return instance.Map(source);
    }

    public TDestination Map<TDestination>(object source)
    {
        var destinationType = typeof(TDestination);
        var genericType = typeof(IMappingProfile<,>).MakeGenericType(source.GetType(), destinationType);

        var instance = _serviceProvider.GetService(genericType);

        if (instance is null)
            throw new NotImplementedException($"Can not found the mapper for the types Source: {source.GetType()} || Destination: {destinationType}");

        var method = genericType.GetMethod("Map");

        return (TDestination)method?.Invoke(instance, new[] { source })!;
    }
}
