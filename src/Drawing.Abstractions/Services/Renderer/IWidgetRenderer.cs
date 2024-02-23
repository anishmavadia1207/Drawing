using Drawing.Abstractions.Models;

namespace Drawing.Abstractions.Services.Renderer;

/// <summary>
/// Represents a service for rendering a widget.
/// </summary>
public interface IWidgetRenderer
{
    /// <summary>
    /// Represents a service for rendering a widget.
    /// </summary>
    /// <param name="widget">The widget to be rendered.</param>
    /// <returns>A st
    public string Render(Widget widget);
}
