namespace Drawing.Abstractions.Models;

/// <summary>
/// Represents a drawing composed of multiple widgets.
/// </summary>
public class WidgetedDrawing
{
    /// <summary>
    /// Initializes a new instance of the WidgetedDrawing class with the specified widgets.
    /// </summary>
    /// <param name="widgets">The widgets that make up the drawing.</param>
    public WidgetedDrawing(IEnumerable<Widget> widgets) => Widgets = widgets;

    /// <summary>
    /// Gets the widgets that make up the drawing.
    /// </summary>
    public IEnumerable<Widget> Widgets { get; }
}