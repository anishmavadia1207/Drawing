using Drawing.Abstractions.Models;
using Drawing.Abstractions.Models.Shapes.Base;
using Drawing.Abstractions.Services.Strategies;

namespace Drawing.Core.Services.Strategies;
/// <summary>
/// Represents a rendering strategy for circular shapes.
/// </summary>
public class CircularShapeStrategy : IRenderStrategy
{
    /// <summary>
    /// Gets the rendering result based on the provided widget.
    /// </summary>
    /// <param name="widget">The widget to be rendered.</param>
    /// <returns>
    /// A string representing the rendering result. If the widget's shape is circular, 
    /// returns either the diameter if it's not an ellipse, or both horizontal and vertical diameters 
    /// if it's an ellipse. Otherwise, returns an empty string.
    /// </returns>
    public string GetStrategyResult(Widget widget)
    {
        if (widget.Shape is CircularShape circularShape)
        {
            return circularShape.HorizontalDiameter == circularShape.VerticalDiameter ?
                $"size={circularShape.HorizontalDiameter}" :
                $"diameterH = {circularShape.HorizontalDiameter} diameterV = {circularShape.VerticalDiameter}";
        }

        return string.Empty;
    }
}

