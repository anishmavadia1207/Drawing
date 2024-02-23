using Drawing.Abstractions.Models;
using Drawing.Abstractions.Services.Strategies;

namespace Drawing.Core.Services.Strategies;
/// <summary>
/// Represents a rendering strategy for determining the type of shape.
/// </summary>
public class ShapeTypeStrategy : IRenderStrategy
{
    /// <summary>
    /// Gets the rendering result based on the type of shape of the provided widget.
    /// </summary>
    /// <param name="widget">The widget whose shape type is to be determined.</param>
    /// <returns>
    /// A string representing the type of shape of the widget.
    /// </returns>
    public string GetStrategyResult(Widget widget) =>
        widget.Shape.GetType().Name;
}
