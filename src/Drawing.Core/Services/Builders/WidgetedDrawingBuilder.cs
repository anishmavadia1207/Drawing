using Drawing.Abstractions.Models;
using Drawing.Abstractions.Services.Builders;

namespace Drawing.Core.Services.Builders;
public class WidgetedDrawingBuilder : IWidgetedDrawingBuilder
{
    internal readonly List<Widget> _widgets = [];

    /// <inheritdoc/>
    public IWidgetedDrawingBuilder AddWidget(Widget widget)
    {
        _widgets.Add(widget);
        return this;
    }

    /// <inheritdoc/>
    public WidgetedDrawing Build()
    {
        return new WidgetedDrawing(_widgets);
    }
}
