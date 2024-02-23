﻿using Drawing.Abstractions.Models.Shapes.Base;

namespace Drawing.Abstractions.Models.Shapes;
/// <summary>
/// Represents a square, inheriting from <see cref="RectanglularShape"/>.
/// </summary>
/// <remarks>
/// a square is a special type of <see cref="RectanglularShape"/> where the width and height are equal.
/// </remarks>
public class Square : RectanglularShape
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Square"/> class with the specified side length.
    /// </summary>
    /// <param name="width">The side length of the square.</param>
    public Square(int width) : base(width, width)
    {
    }
}
