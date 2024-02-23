using Drawing.Abstractions.Models;
using Drawing.Test.Generators;

using FluentAssertions;

namespace Drawing.Abstractions.Test.Unit.Models;
public class WidgetDrawingShould
{
    [Fact]
    public void Initialise_Widgets_When_Constructing()
    {
        Widget[] widgets =
        [
            TestGenerator.WidgetGenerator().Generate(),
            TestGenerator.WidgetGenerator().Generate()
        ];
        var widgetDrawing = new WidgetDrawing(widgets);

        widgetDrawing.Widgets.Should().BeEquivalentTo(widgets);
    }
}