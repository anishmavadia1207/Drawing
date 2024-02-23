using Drawing.Abstractions.Models;

namespace Drawing.Abstractions.Services.Builders;

/// <summary>
/// Represents a service for building widgeted drawings.
/// </summary>
public interface IWidgetedDrawingBuilder
{
    /// <summary>
    /// Adds a widget to the drawing being built.
    /// </summary>
    /// <param name="widget">The widget to add.</param>
    /// <returns>The current instance of the builder.</returns>
    public IWidgetedDrawingBuilder AddWidget(Widget widget);

    /// <summary>
    /// Builds the widgeted drawing based on the added widgets.
    /// </summary>
    /// <returns>The constructed widgeted drawing.</returns>
    public WidgetedDrawing Build();
}