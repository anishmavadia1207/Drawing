using Drawing.Abstractions.Models;
using Drawing.Abstractions.Models.Shapes.Base;
using Drawing.Abstractions.Services.Strategies;

namespace Drawing.Core.Services.Strategies;
public class RectangularShapeStrategy : IRenderStrategy
{
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
