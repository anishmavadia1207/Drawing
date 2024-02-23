using Drawing.Abstractions.Models;
using Drawing.Abstractions.Services.Strategies;

namespace Drawing.Core.Services.Strategies;
public class PositionStrategy : IRenderStrategy
{
    public string GetStrategyResult(Widget widget) =>
        $"({widget.Position.X}, {widget.Position.Y})";
}
