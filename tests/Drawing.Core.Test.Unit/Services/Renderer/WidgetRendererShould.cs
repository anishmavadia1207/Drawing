using Drawing.Abstractions.Models;
using Drawing.Abstractions.Services.Strategies;
using Drawing.Core.Services.Renderer;
using Drawing.Test.Generators;

using FluentAssertions;
using FluentAssertions.Execution;

namespace Drawing.Core.Test.Unit.Services.Renderer;
public class WidgetRendererShould
{
    private readonly WidgetRenderer _renderer;
    private readonly IEnumerable<IRenderStrategy> _strategies;
    public WidgetRendererShould()
    {
        _strategies =
        [
            new FirstStrategy(),
            new SecondStrategy(),
            new ThirdStrategy()
        ];

        _renderer = new WidgetRenderer(_strategies);
    }

    [Fact]
    public void Use_StrategyOrder_When_Rendering()
    {
        var widget = TestGenerator.WidgetGenerator().Generate();

        var rendered = _renderer.Render(widget);

        using var scope = new AssertionScope();
        rendered.Should().Be("1 2 3");
    }

    [Fact]
    public void Trim_ExcessWhiteSpace_When_Rendering()
    {
        var widget = TestGenerator.WidgetGenerator().Generate();

        var rendered = _renderer.Render(widget);

        using var scope = new AssertionScope();
        rendered.Should().NotEndWith(" ");
        rendered.Should().NotStartWith(" ");
    }

    private class FirstStrategy : IRenderStrategy
    {
        public string GetStrategyResult(Widget widget) => "   1";
    }

    private class SecondStrategy : IRenderStrategy
    {
        public string GetStrategyResult(Widget widget) => "2";
    }

    private class ThirdStrategy : IRenderStrategy
    {
        public string GetStrategyResult(Widget widget) => "3    ";
    }
}
