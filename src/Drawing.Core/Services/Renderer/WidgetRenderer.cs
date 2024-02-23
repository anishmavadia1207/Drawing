using System.Text;

using Drawing.Abstractions.Models;
using Drawing.Abstractions.Services.Renderer;
using Drawing.Abstractions.Services.Strategies;

namespace Drawing.Core.Services.Renderer;
/// <summary>
/// Responsible for rendering widgets using a collection of rendering strategies.
/// This class iterates through a set of <see cref="IRenderStrategy"/> instances,
/// applying each strategy to the widget and concatenating the results.
/// </summary>
public class WidgetRenderer : IWidgetRenderer
{
    private readonly IEnumerable<IRenderStrategy> _renderStrategies;

    /// <summary>
    /// Initializes a new instance of the <see cref="WidgetRenderer"/> class with the specified rendering strategies.
    /// </summary>
    /// <param name="renderStrategies">A collection of strategies used for rendering widgets.</param>
    public WidgetRenderer(IEnumerable<IRenderStrategy> renderStrategies) =>
        _renderStrategies = renderStrategies;

    /// <summary>
    /// Renders the specified widget using all configured rendering strategies.
    /// </summary>
    /// <param name="widget">The widget to be rendered.</param>
    /// <returns>A string that represents the combined result of all rendering strategies applied to the widget.</returns>
    public string Render(Widget widget)
    {
        var widgetBuilder = new StringBuilder();
        foreach (var renderStrategy in _renderStrategies)
        {
            var result = renderStrategy.GetStrategyResult(widget);
            if (!string.IsNullOrWhiteSpace(result))
            {
                widgetBuilder.Append(result + " ");
            }
        }
        return widgetBuilder.ToString().Trim();
    }
}
