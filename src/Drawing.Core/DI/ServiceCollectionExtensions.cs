using Drawing.Abstractions.DI;
using Drawing.Abstractions.Services.Strategies;
using Drawing.Core.Services;
using Drawing.Core.Services.Builders;
using Drawing.Core.Services.Renderer;
using Drawing.Core.Services.Strategies;

using Microsoft.Extensions.DependencyInjection;

namespace Drawing.Core.DI;

/// <summary>
/// Extension methods for adding core drawing-related services to the <see cref="IServiceCollection"/>.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds core drawing-related services to the <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="this">The <see cref="IServiceCollection"/> to add the services to.</param>
    /// <param name="serviceLifetime">The service lifetime to use for the added services (default is <see cref="ServiceLifetime.Scoped"/>).</param>
    /// <returns>The modified <see cref="IServiceCollection"/> instance.</returns>
    /// <remarks>
    /// This method registers core drawing services including <see cref="DrawingService"/>, 
    /// <see cref="WidgetDrawingBuilder"/>, and <see cref="WidgetRenderer"/>, along with 
    /// rendering strategies such as <see cref="ShapeTypeStrategy"/>, <see cref="PositionStrategy"/>, 
    /// <see cref="CircularShapeStrategy"/>, and <see cref="RectangularShapeStrategy"/>.
    /// </remarks>
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
