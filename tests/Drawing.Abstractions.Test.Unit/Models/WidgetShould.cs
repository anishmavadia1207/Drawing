using Drawing.Abstractions.Models;
using Drawing.Abstractions.Models.Shapes.Base;

using FluentAssertions;
using FluentAssertions.Execution;

using NSubstitute;

namespace Drawing.Abstractions.Test.Unit.Models;
public class WidgetShould
{
    [Fact]
    public void Initialise_PositionAndShape_When_Constructing()
    {
        var position = new Position(10, 20);
        var shapeMock = Substitute.For<IShape>();

        var widget = new Widget(position, shapeMock);

        using var scope = new AssertionScope();
        widget.Position.Should().Be(position);
        widget.Shape.Should().Be(shapeMock);
    }
}