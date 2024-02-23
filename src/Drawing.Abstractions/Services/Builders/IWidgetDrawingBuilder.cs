using Drawing.Abstractions.Models;

namespace Drawing.Abstractions.Services.Builders;

/// <summary>
/// Represents a service for building widget drawings.
/// </summary>
public interface IWidgetDrawingBuilder
{
    /// <summary>
    /// Adds a widget to the drawing being built.
    /// </summary>
    /// <param name="widget">The widget to add.</param>
    /// <returns>The current instance of the builder.</returns>
    public IWidgetDrawingBuilder AddWidget(Widget widget);

    /// <summary>
    /// Builds the widget drawing based on the added widgets.
    /// </summary>
    /// <returns>The constructed widget drawing.</returns>
    public WidgetDrawing Build();
}