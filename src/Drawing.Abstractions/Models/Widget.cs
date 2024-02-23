using Drawing.Abstractions.Models.Shapes.Base;

namespace Drawing.Abstractions.Models;

/// <summary>
/// Represents a widget with a position and a shape.
/// </summary>
public class Widget
{
    /// <summary>
    /// Initializes a new instance of the Widget class with the specified position and shape.
    /// </summary>
    /// <param name="position">The position of the widget.</param>
    /// <param name="shape">The shape of the widget.</param>
    public Widget(Position position, IShape shape) =>
        (Position, Shape) =
        (position, shape);

    /// <summary>
    /// Gets the position of the widget.
    /// </summary>
    public Position Position { get; }

    /// <summary>
    /// Gets the shape of the widget.
    /// </summary>
    public IShape Shape { get; }
}