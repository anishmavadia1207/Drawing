using Drawing.Abstractions.Models.Shapes.Base;

namespace Drawing.Abstractions.Models.Shapes;
/// <summary>
/// Represents a circle, inheriting from <see cref="CircularShape"/>.
/// </summary>
/// <remarks>
/// A circle is a special case of a <see cref="CircularShape"/> where the diameter is equal in both dimensions.
/// </remarks>
public class Circle : CircularShape
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Circle"/> class with the specified diameter.
    /// </summary>
    /// <param name="diameter">The diameter of the circle.</param>
    public Circle(int diameter) :
        base(diameter, diameter)
    {
    }
}
