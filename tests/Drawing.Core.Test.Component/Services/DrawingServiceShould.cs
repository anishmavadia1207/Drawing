using Drawing.Abstractions.Models;
using Drawing.Abstractions.Models.Shapes;
using Drawing.Abstractions.Services;
using Drawing.Abstractions.Services.Builders;
using Drawing.Core.DI;

using FluentAssertions;
using FluentAssertions.Execution;

using Microsoft.Extensions.DependencyInjection;

namespace Drawing.Core.Test.Component.Services;
public class DrawingServiceShould
{
    private readonly IDrawingService _entryPoint;
    private readonly IWidgetDrawingBuilder _widgetDrawingBuilder;
    public DrawingServiceShould()
    {
        var services = new ServiceCollection();
        services.AddCoreDrawingServices();

        var serviceProvider = services.BuildServiceProvider();
        _entryPoint = serviceProvider.GetRequiredService<IDrawingService>();
        _widgetDrawingBuilder = serviceProvider.GetRequiredService<IWidgetDrawingBuilder>();
    }

    [Fact]
    public void Return_ExpectedRenderContent_When_Drawing()
    {
        var expectedStrings = new List<string>
        {
            "Rectangle (10,10) width=30 height=40",
            "Square (15,30) size=35",
            "Ellipse (100,150) diameterH = 300 diameterV = 200",
            "Circle (1,1) size=300",
            "Textbox (5,5) width=200 height=100 Text=\"sample text\""
        };

        _widgetDrawingBuilder
            .AddWidget(new Widget(new Position(10, 10), new Rectangle(30, 40)))
            .AddWidget(new Widget(new Position(15, 30), new Square(35)))
            .AddWidget(new Widget(new Position(100, 150), new Ellipse(300, 200)))
            .AddWidget(new Widget(new Position(1, 1), new Circle(300)))
            .AddWidget(new Widget(new Position(5, 5), new Textbox(200, 100, "sample text")));

        var drawing = _widgetDrawingBuilder.Build();
        var result = _entryPoint.Draw(drawing);

        using var scope = new AssertionScope();
        var fullResult = string.Join(Environment.NewLine, expectedStrings).Trim();
        result.Should().BeEquivalentTo(fullResult);
    }
}
