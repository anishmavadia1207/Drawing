using Drawing.Abstractions.Models;
using Drawing.Abstractions.Services.Builders;

namespace Drawing.Core.Services.Builders;
public class WidgetDrawingBuilder : IWidgetDrawingBuilder
{
    internal readonly List<Widget> _widgets = [];

    /// <inheritdoc/>
    public IWidgetDrawingBuilder AddWidget(Widget widget)
    {
        _widgets.Add(widget);
        return this;
    }

    /// <inheritdoc/>
    public WidgetDrawing Build() => new WidgetDrawing(_widgets);
}
