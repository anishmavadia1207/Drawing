using Drawing.Abstractions.Models;
using Drawing.Abstractions.Models.Shapes.Base;

using FluentAssertions;

using NSubstitute;

namespace Drawing.Abstractions.Test.Unit.Models;
public class WidgetedDrawingShould
{
    [Fact]
    public void Initialise_Widgets_When_Constructing()
    {
        var widgets = new List<Widget>
        {
            new Widget(new Position(10, 20), Substitute.For<IShape>()),
            new Widget(new Position(30, 40), Substitute.For<IShape>())
        };

        var widgetedDrawing = new WidgetedDrawing(widgets);

        widgetedDrawing.Widgets.Should().BeEquivalentTo(widgets);
    }
}