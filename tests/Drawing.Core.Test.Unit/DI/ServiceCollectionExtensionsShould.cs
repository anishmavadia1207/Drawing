using Drawing.Abstractions.Services;
using Drawing.Abstractions.Services.Builders;
using Drawing.Abstractions.Services.Renderer;
using Drawing.Abstractions.Services.Strategies;
using Drawing.Core.DI;
using Drawing.Core.Services;
using Drawing.Core.Services.Builders;
using Drawing.Core.Services.Renderer;
using Drawing.Core.Services.Strategies;

using FluentAssertions;
using FluentAssertions.Execution;

using Microsoft.Extensions.DependencyInjection;

namespace Drawing.Core.Test.Unit.DI;
public class ServiceCollectionExtensionsShould
{
    private readonly ServiceCollection _services;
    public ServiceCollectionExtensionsShould() => _services = new();

    [Fact]
    public void Add_DrawingService_When_Registering()
    {
        _services.AddCoreDrawingServices();

        using var scope = new AssertionScope();
        _services.Where(s =>
            s.ServiceType == typeof(IDrawingService) &&
            s.ImplementationType == typeof(DrawingService) &&
            s.Lifetime == ServiceLifetime.Scoped)
            .Should().HaveCount(1);
    }

    [Fact]
    public void Add_WidgetRenderer_When_Registering()
    {
        _services.AddCoreDrawingServices();

        using var scope = new AssertionScope();
        _services.Where(s =>
            s.ServiceType == typeof(IWidgetRenderer) &&
            s.ImplementationType == typeof(WidgetRenderer) &&
            s.Lifetime == ServiceLifetime.Scoped)
            .Should().HaveCount(1);
    }

    [Fact]
    public void Add_WidgetDrawingBuilder_When_Registering()
    {
        _services.AddCoreDrawingServices();

        using var scope = new AssertionScope();
        _services.Where(s =>
            s.ServiceType == typeof(IWidgetDrawingBuilder) &&
            s.ImplementationType == typeof(WidgetDrawingBuilder) &&
            s.Lifetime == ServiceLifetime.Scoped)
            .Should().HaveCount(1);
    }

    [Fact]
    public void Add_Strategies_When_Registering()
    {
        _services.AddCoreDrawingServices();

        using var scope = new AssertionScope();
        _services.Where(s =>
            s.ServiceType == typeof(IRenderStrategy) &&
            s.ImplementationType == typeof(ShapeSizeStrategy) &&
            s.Lifetime == ServiceLifetime.Singleton)
            .Should().HaveCount(1);

        _services.Where(s =>
            s.ServiceType == typeof(IRenderStrategy) &&
            s.ImplementationType == typeof(ShapeTypeStrategy) &&
            s.Lifetime == ServiceLifetime.Singleton)
            .Should().HaveCount(1);

        _services.Where(s =>
            s.ServiceType == typeof(IRenderStrategy) &&
            s.ImplementationType == typeof(PositionStrategy) &&
            s.Lifetime == ServiceLifetime.Singleton)
            .Should().HaveCount(1);
    }
}
