
namespace Drawing.Abstractions.Models.Shapes.Base;

/// <summary>
/// Represents an abstract rectangular shape.
/// </summary>
public abstract class RectangularShape : IShape
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RectangularShape"/> class with the specified width and height.
    /// </summary>
    /// <param name="width">The width of the rectangular shape.</param>
    /// <param name="height">The height of the rectangular shape.</param>
    protected RectangularShape(int width, int height)
    {
        Validate(width, height);

        (Width, Height) =
        (width, height);
    }

    /// <summary>
    /// Gets the width of the rectangular shape.
    /// </summary>
    public int Width { get; }

    /// <summary>
    /// Gets the height of the rectangular shape.
    /// </summary>
    public int Height { get; }

    private static void Validate(int width, int height)
    {
        if (width <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(width),
                "The width must be greater than 0.");
        }

        if (height <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(height),
                "The height must be greater than 0.");
        }
    }
}
