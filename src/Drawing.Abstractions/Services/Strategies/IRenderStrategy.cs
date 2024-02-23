using Drawing.Abstractions.Models;

namespace Drawing.Abstractions.Services.Strategies;

/// <summary>
/// Defines a strategy for rendering widgets.
/// This interface is responsible for providing a mechanism to render
/// different types of widgets based on the specific strategy implemented by the concrete class.
/// </summary>
public interface IRenderStrategy
{
    /// <summary>
    /// Gets the result of the rendering strategy applied to the specified widget.
    /// </summary>
    /// <param name="widget">The widget to render.</param>
    /// <returns>A string representing the outcome of the rendering process. 
    /// This might include details such as rendering metrics, a description of the rendering process,
    /// or any other relevant information specific to the strategy implementation.</returns>
    public string GetStrategyResult(Widget widget);
}
