/// <summary>
/// Represents an abstract circular shape.
/// </summary>
namespace Drawing.Abstractions.Models.Shapes.Base;

public abstract class CircularShape : IShape
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CircularShape"/> class with the specified horizontal and vertical diameters.
    /// </summary>
    /// <param name="horizontalDiameter">The diameter of the circular shape along its horizontal axis.</param>
    /// <param name="verticalDiameter">The diameter of the circular shape along its vertical axis.</param>
    protected CircularShape(int horizontalDiameter, int verticalDiameter)
    {
        Validate(horizontalDiameter, verticalDiameter);

        (HorizontalDiameter, VerticalDiameter) =
        (horizontalDiameter, verticalDiameter);
    }

    /// <summary>
    /// Gets the diameter of the circular shape along its horizontal axis.
    /// </summary>
    public int HorizontalDiameter { get; }

    /// <summary>
    /// Gets the diameter of the circular shape along its vertical axis.
    /// </summary>
    public int VerticalDiameter { get; }


    private static void Validate(int horizontalDiameter, int verticalDiameter)
    {
        if (horizontalDiameter <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(horizontalDiameter),
                "The horizontal diameter must be greater than 0.");
        }

        if (verticalDiameter <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(verticalDiameter),
                "The vertical diameter must be greater than 0.");
        }
    }
}
