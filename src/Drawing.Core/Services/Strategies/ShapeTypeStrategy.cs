using Drawing.Abstractions.Models;
using Drawing.Abstractions.Services.Strategies;

namespace Drawing.Core.Services.Strategies;
public class ShapeTypeStrategy : IRenderStrategy
{
    public string GetStrategyResult(Widget widget) =>
        widget.Shape.GetType().Name;
}
