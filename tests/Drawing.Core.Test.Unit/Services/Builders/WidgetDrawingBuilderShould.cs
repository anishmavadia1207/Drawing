using Drawing.Abstractions.Models;
using Drawing.Core.Services.Builders;
using Drawing.Test.Generators;

using FluentAssertions;

public class WidgetDrawingBuilderShould
{
    [Fact]
    public void Update_Collection_When_AddingWidget()
    {
        var builder = new WidgetDrawingBuilder();
        var widget = TestGenerator.WidgetGenerator().Generate();

        builder.AddWidget(widget);

        builder._widgets.Should().Contain(widget);
    }

    [Fact]
    public void Return_BuiltWidgetDrawing_When_BuildingCollection()
    {
        var builder = new WidgetDrawingBuilder();
        var widgets = new List<Widget>
        {
            TestGenerator.WidgetGenerator().Generate(),
            TestGenerator.WidgetGenerator().Generate()
        };

        foreach (var widget in widgets)
        {
            builder.AddWidget(widget);
        }

        var widgetDrawing = builder.Build();

        widgetDrawing.Widgets.Should().BeEquivalentTo(widgets);
    }
}