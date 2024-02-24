using Drawing.Abstractions.Models;
using Drawing.Core.Services.Strategies;
using Drawing.Test.Generators;

using FluentAssertions;

namespace Drawing.Core.Test.Unit.Services.Strategies;
public class ShapeTypeStrategyShould
{
    private readonly ShapeTypeStrategy _strategy;
    public ShapeTypeStrategyShould() => _strategy = new();

    public static object[][] ShapeWidgetData =>
    [
        [TestGenerator.WidgetGenerator(shape: TestGenerator.CircleGenerator().Generate()).Generate(), "Circle"],
        [TestGenerator.WidgetGenerator(shape: TestGenerator.SquareGenerator().Generate()).Generate(), "Square"],
        [TestGenerator.WidgetGenerator(shape: TestGenerator.RectangleGenerator().Generate()).Generate(), "Rectangle"],
        [TestGenerator.WidgetGenerator(shape: TestGenerator.EllipseGenerator().Generate()).Generate(), "Ellipse"],
        [TestGenerator.WidgetGenerator(shape: TestGenerator.TextboxGenerator().Generate()).Generate(), "Textbox"]
    ];

    [Theory]
    [MemberData(nameof(ShapeWidgetData))]
    public void Return_CorrectTypeName_When_GettingResult(Widget widget, string typeName)
    {
        var result = _strategy.GetStrategyResult(widget);

        result.Should().Be(typeName);
    }

}
