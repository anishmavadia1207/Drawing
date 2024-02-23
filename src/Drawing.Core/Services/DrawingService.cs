using System.Text;

using Drawing.Abstractions.Models;
using Drawing.Abstractions.Services;
using Drawing.Abstractions.Services.Renderer;

namespace Drawing.Core.Services;
/// <summary>
/// Service for drawing widgets
/// </summary>
public class DrawingService : IDrawingService
{
    private readonly IWidgetRenderer _widgetRenderer;

    /// <summary>
    /// Initializes a new instance of the <see cref="DrawingService"/> class.
    /// </summary>
    /// <param name="widgetRenderer">The renderer used to render widgets.</param>
    public DrawingService(IWidgetRenderer widgetRenderer) =>
        _widgetRenderer = widgetRenderer;


    /// <inheritdoc/>
    public string Draw(WidgetDrawing widgetDrawing)
    {
        var drawingBuilder = new StringBuilder();

        foreach (var widget in widgetDrawing.Widgets)
        {
            var renderedWidget = _widgetRenderer.Render(widget);
            drawingBuilder.AppendLine(renderedWidget);
        }

        return drawingBuilder.ToString().Trim();
    }
}
