using Drawing.Abstractions.Models.Shapes.Base;

namespace Drawing.Abstractions.Models.Shapes;
/// <summary>
/// Represents an ellipse, inheriting from <see cref="CircularShape"/>.
/// </summary>
/// <remarks>
/// An ellipse is a type of <see cref="CircularShape"/> that may have different diameters along its horizontal and vertical axes.
/// </remarks>
public class Ellipse : CircularShape
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Ellipse"/> class with the specified horizontal and vertical diameters.
    /// </summary>
    /// <param name="horizontalDiameter">The diameter of the ellipse along its horizontal axis.</param>
    /// <param name="verticalDiameter">The diameter of the ellipse along its vertical axis.</param>
    public Ellipse(int horizontalDiameter, int verticalDiameter) : base(horizontalDiameter, verticalDiameter)
    {
    }
}
