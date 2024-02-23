using Drawing.Abstractions.Models.Shapes.Base;

namespace Drawing.Abstractions.Models.Shapes;

/// <summary>
/// Represents a rectangle, inheriting from <see cref="RectanglularShape"/>.
/// </summary>
public class Rectangle : RectanglularShape
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Rectangle"/> class with the specified width and height.
    /// </summary>
    /// <param name="width">The width of the rectangle.</param>
    /// <param name="height">The height of the rectangle.</param>
    public Rectangle(int width, int height) :
        base(width, height)
    {
    }
}
