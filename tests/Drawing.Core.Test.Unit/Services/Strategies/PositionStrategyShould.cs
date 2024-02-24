using Drawing.Core.Services.Strategies;
using Drawing.Test.Generators;

using FluentAssertions;

namespace Drawing.Core.Test.Unit.Services.Strategies;
public class PositionStrategyShould
{
    private readonly PositionStrategy _strategy;
    public PositionStrategyShould() => _strategy = new();

    [Fact]
    public void Return_CorrectPosition_When_GettingResult()
    {
        var widget = TestGenerator.WidgetGenerator().Generate();
        var result = _strategy.GetStrategyResult(widget);

        result.Should().Be($"({widget.Position.X},{widget.Position.Y})");
    }

}
