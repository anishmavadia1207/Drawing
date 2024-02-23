using Drawing.Abstractions.Models;
using Drawing.Abstractions.Services.Strategies;

namespace Drawing.Core.Services.Strategies;
/// <summary>
/// Represents a rendering strategy for positioning widgets.
/// </summary>
public class PositionStrategy : IRenderStrategy
{
    /// <summary>
    /// Gets the rendering result based on the position of the provided widget.
    /// </summary>
    /// <param name="widget">The widget whose position is to be rendered.</param>
    /// <returns>
    /// A string representing the position of the widget in the format (X, Y).
    /// </returns>
    public string GetStrategyResult(Widget widget) =>
        $"({widget.Position.X},{widget.Position.Y})";
}