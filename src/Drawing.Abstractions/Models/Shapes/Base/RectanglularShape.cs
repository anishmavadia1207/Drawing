﻿namespace Drawing.Abstractions.Models.Shapes.Base;

/// <summary>
/// Represents an abstract rectangular shape.
/// </summary>
public abstract class RectanglularShape : IShape
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RectanglularShape"/> class with the specified width and height.
    /// </summary>
    /// <param name="width">The width of the rectangular shape.</param>
    /// <param name="height">The height of the rectangular shape.</param>
    protected RectanglularShape(int width, int height) =>
        (Width, Height) = (width, height);

    /// <summary>
    /// Gets the width of the rectangular shape.
    /// </summary>
    public int Width { get; }

    /// <summary>
    /// Gets the height of the rectangular shape.
    /// </summary>
    public int Height { get; }
}
