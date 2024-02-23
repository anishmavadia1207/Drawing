using Drawing.Abstractions.Models;
using Drawing.Abstractions.Models.Shapes.Base;
using Drawing.Abstractions.Services.Strategies;

namespace Drawing.Core.Services.Strategies;
/// <summary>
/// Represents a rendering strategy for rectangular shapes.
/// </summary>
public class RectangularShapeStrategy : IRenderStrategy
{
    /// <summary>
    /// Gets the rendering result based on the provided widget.
    /// </summary>
    /// <param name="widget">The widget to be rendered.</param>
    /// <returns>
    /// A string representing the rendering result. If the widget's shape is rectangular, 
    /// returns either the size if it's a square, or both width and height if it's a rectangle.
    /// Otherwise, returns an empty string.
    /// </returns>
    public string GetStrategyResult(Widget widget)
    {
        if (widget.Shape is RectangularShape rectangularShape)
        {
            return rectangularShape.Width == rectangularShape.Height ?
                $"size={rectangularShape.Width}" :
                $"width={rectangularShape.Width} height={rectangularShape.Height}";
        }

        return string.Empty;
    }
}

