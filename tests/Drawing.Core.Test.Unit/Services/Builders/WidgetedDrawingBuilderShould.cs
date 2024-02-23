using Drawing.Abstractions.Models;
using Drawing.Abstractions.Models.Shapes;
using Drawing.Core.Services;

using FluentAssertions;

public class WidgetedDrawingBuilderTests
{
    [Fact]
    public void Update_Collection_When_AddingWidget()
    {
        var builder = new WidgetedDrawingBuilder();
        var widget = new Widget(new Position(10, 20), new Circle(5));

        builder.AddWidget(widget);

        builder._widgets.Should().Contain(widget);
    }

    [Fact]
    public void Return_BuiltWidgetedDrawing_When_BuildingCollection()
    {
        var builder = new WidgetedDrawingBuilder();
        var widgets = new List<Widget>
        {
            new Widget(new Position(10, 20), new Circle(5)),
            new Widget(new Position(30, 40), new Rectangle(6, 8))
        };

        foreach (var widget in widgets)
        {
            builder.AddWidget(widget);
        }

        // Act
        var widgetedDrawing = builder.Build();

        widgetedDrawing.Widgets.Should().BeEquivalentTo(widgets);
    }
}