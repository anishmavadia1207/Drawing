/// <summary>
/// Represents a position with X and Y coordinates.
/// </summary>
namespace Drawing.Abstractions.Models;

public class Position
{
    /// <summary>
    /// Initializes a new instance of the Position class with the specified coordinates.
    /// </summary>
    /// <param name="x">The X coordinate.</param>
    /// <param name="y">The Y coordinate.</param>
    public Position(int x, int y) =>
        (X, Y) =
        (x, y);

    /// <summary>
    /// Gets the X coordinate of the position.
    /// </summary>
    public int X { get; }

    /// <summary>
    /// Gets the Y coordinate of the position.
    /// </summary>
    public int Y { get; }
}