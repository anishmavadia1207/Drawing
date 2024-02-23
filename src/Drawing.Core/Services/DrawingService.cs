using System.Text;

using Drawing.Abstractions.Models;
using Drawing.Abstractions.Services;
using Drawing.Abstractions.Services.Renderer;

namespace Drawing.Core.Services;
public class DrawingService : IDrawingService
{
    private readonly IWidgetRenderer _widgetRenderer;

    public DrawingService(IWidgetRenderer widgetRenderer) =>
        _widgetRenderer = widgetRenderer;


    public string Draw(WidgetDrawing widgetDrawing)
    {
        var drawingBuilder = new StringBuilder();

        foreach (var widget in widgetDrawing.Widgets)
        {
            var renderedWidget = _widgetRenderer.Render(widget);
            drawingBuilder.AppendLine(renderedWidget);
        }

        return drawingBuilder.ToString();
    }
}
