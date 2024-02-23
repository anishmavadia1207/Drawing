using Drawing.Abstractions.Models;
using Drawing.Abstractions.Models.Shapes;
using Drawing.Abstractions.Services.Strategies;

namespace Drawing.Core.Services.Strategies;
public class ShapeSizeStrategy : IRenderStrategy
{
    public string GetStrategyResult(Widget widget) => widget.Shape switch
    {
        Rectangle rectangle => $"width={rectangle.Width} height={rectangle.Height}",
        Square square => $"size={square.Width}",
        Circle circle => $"size={circle.HorizontalDiameter}",
        Ellipse ellipse => $"diameterH = {ellipse.HorizontalDiameter} diameterV = {ellipse.VerticalDiameter}",
        Textbox textbox => $"width={textbox.Width} height={textbox.Height} Text=\"{textbox.Text}\"",
        _ => string.Empty
    };
}
