using Drawing.Abstractions.DI;
using Drawing.Abstractions.Services.Strategies;
using Drawing.Core.Services;
using Drawing.Core.Services.Builders;
using Drawing.Core.Services.Renderer;
using Drawing.Core.Services.Strategies;

using Microsoft.Extensions.DependencyInjection;

namespace Drawing.Core.DI;

/// <summary>
/// Extension methods for adding drawing-related services to the <see cref="IServiceCollection"/>.
/// </summary>
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCoreDrawingServices(
        this IServiceCollection @this,
        ServiceLifetime serviceLifetime = ServiceLifetime.Scoped)
    {
        @this.AddDrawingServices<DrawingService, WidgetDrawingBuilder, WidgetRenderer>(serviceLifetime);
        @this.AddSingleton<IRenderStrategy, ShapeTypeStrategy>();
        @this.AddSingleton<IRenderStrategy, PositionStrategy>();
        @this.AddSingleton<IRenderStrategy, CircularShapeStrategy>();
        @this.AddSingleton<IRenderStrategy, RectangularShapeStrategy>();

        return @this;
    }
}
