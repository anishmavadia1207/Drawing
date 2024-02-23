using System.Text;

using Drawing.Abstractions.Models;
using Drawing.Abstractions.Services.Renderer;
using Drawing.Abstractions.Services.Strategies;

namespace Drawing.Core.Services.Renderer;
public class WidgetRenderer : IWidgetRenderer
{
    private readonly IEnumerable<IRenderStrategy> _renderStrategies;
    public WidgetRenderer(IEnumerable<IRenderStrategy> renderStrategies) =>
        _renderStrategies = renderStrategies;


    public string Render(Widget widget)
    {
        var widgetBuilder = new StringBuilder();
        foreach (var renderStrategy in _renderStrategies)
        {
            widgetBuilder.Append(renderStrategy.GetStrategyResult(widget));
        }
        return widgetBuilder.ToString();
    }
}
