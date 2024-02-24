using Drawing.Abstractions.Models;
using Drawing.Abstractions.Models.Shapes;
using Drawing.Core.Services.Strategies;
using Drawing.Test.Generators;

using FluentAssertions;

namespace Drawing.Core.Test.Unit.Services.Strategies;
public class ShapeSizeStrategyShould
{
    private readonly ShapeSizeStrategy _strategy;
    public ShapeSizeStrategyShould() => _strategy = new();

    public static object[][] ShapeWidgetData =>
    [
        [TestGenerator.WidgetGenerator(shape: TestGenerator.CircleGenerator().Generate()).Generate()],
        [TestGenerator.WidgetGenerator(shape: TestGenerator.SquareGenerator().Generate()).Generate()],
        [TestGenerator.WidgetGenerator(shape: TestGenerator.RectangleGenerator().Generate()).Generate()],
        [TestGenerator.WidgetGenerator(shape: TestGenerator.EllipseGenerator().Generate()).Generate()],
        [TestGenerator.WidgetGenerator(shape: TestGenerator.TextboxGenerator().Generate()).Generate()]
    ];

    [Theory]
    [MemberData(nameof(ShapeWidgetData))]
    public void Return_CorrectTypeName_When_GettingResult(Widget widget)
    {
        var shapeSizeResult = widget.Shape switch
        {
            Rectangle rectangle => $"width={rectangle.Width} height={rectangle.Height}",
            Square square => $"size={square.Width}",
            Circle circle => $"size={circle.HorizontalDiameter}",
            Ellipse ellipse => $"diameterH = {ellipse.HorizontalDiameter} diameterV = {ellipse.VerticalDiameter}",
            Textbox textbox => $"width={textbox.Width} height={textbox.Height} Text=\"{textbox.Text}\"",
            _ => throw new NotImplementedException()
        };

        var result = _strategy.GetStrategyResult(widget);

        result.Should().Be(shapeSizeResult);
    }

}
