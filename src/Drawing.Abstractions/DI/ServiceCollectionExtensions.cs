using Drawing.Abstractions.Services;
using Drawing.Abstractions.Services.Builders;
using Drawing.Abstractions.Services.Renderer;

using Microsoft.Extensions.DependencyInjection;

namespace Drawing.Abstractions.DI;

/// <summary>
/// Extension methods for adding drawing-related services to the <see cref="IServiceCollection"/>.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds drawing-related services to the <see cref="IServiceCollection"/>.
    /// </summary>
    /// <typeparam name="TDrawingService">The type of drawing service to add.</typeparam>
    /// <typeparam name="TIWidgetDrawingBuilder">The type of widget drawing builder to add.</typeparam>
    /// <typeparam name="TWidgetRenderer">The type of widget renderer to add.</typeparam>
    /// <param name="this">The <see cref="IServiceCollection"/> to add the services to.</param>
    /// <param name="serviceLifetime">The service lifetime to use for the added services (default is <see cref="ServiceLifetime.Scoped"/>).</param>
    /// <returns>The modified <see cref="IServiceCollection"/> instance.</returns>
    /// <remarks>
    /// This method registers the specified drawing service, widget builder, and widget renderer 
    /// types with the specified service lifetime in the <paramref name="this"/> service collection.
    /// </remarks>
    public static IServiceCollection AddDrawingServices<TDrawingService, TIWidgetDrawingBuilder, TWidgetRenderer>(
        this IServiceCollection @this,
        ServiceLifetime serviceLifetime = ServiceLifetime.Scoped)
        where TDrawingService : class, IDrawingService
        where TIWidgetDrawingBuilder : class, IWidgetDrawingBuilder
        where TWidgetRenderer : class, IWidgetRenderer
    {
        @this.Add(
            new ServiceDescriptor(
                typeof(IDrawingService),
                typeof(TDrawingService),
                serviceLifetime));

        @this.Add(
            new ServiceDescriptor(
                typeof(IWidgetDrawingBuilder),
                typeof(TIWidgetDrawingBuilder),
                serviceLifetime));

        @this.Add(
            new ServiceDescriptor(
                typeof(IWidgetRenderer),
                typeof(TWidgetRenderer),
                serviceLifetime));

        return @this;
    }
}
