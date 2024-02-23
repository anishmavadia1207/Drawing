using Drawing.Abstractions.Models;
using Drawing.Abstractions.Models.Shapes.Base;

using FluentAssertions;

using NSubstitute;

namespace Drawing.Abstractions.Test.Unit.Models;
public class WidgetDrawingShould
{
    [Fact]
    public void Initialise_Widgets_When_Constructing()
    {
        Widget[] widgets =
        [
            new Widget(new Position(10, 20), Substitute.For<IShape>()),
            new Widget(new Position(30, 40), Substitute.For<IShape>())
        ];
        var widgetDrawing = new WidgetDrawing(widgets);

        widgetDrawing.Widgets.Should().BeEquivalentTo(widgets);
    }
}