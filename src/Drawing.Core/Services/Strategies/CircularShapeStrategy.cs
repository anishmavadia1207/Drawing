using Drawing.Abstractions.Models;
using Drawing.Abstractions.Models.Shapes.Base;
using Drawing.Abstractions.Services.Strategies;

namespace Drawing.Core.Services.Strategies;
public class CircularShapeStrategy : IRenderStrategy
{
    public string GetStrategyResult(Widget widget)
    {
        if (widget.Shape is CircularShape circularShape)
        {
            return circularShape.HorizontalDiameter == circularShape.VerticalDiameter ?
                $"size={circularShape.HorizontalDiameter}" :
                $"diameterH={circularShape.HorizontalDiameter} diameterV={circularShape.VerticalDiameter}";
        }

        return string.Empty;
    }
}
