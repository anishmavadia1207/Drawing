using Bogus;

using Drawing.Abstractions.Models.Shapes;

using FluentAssertions;
using FluentAssertions.Execution;

namespace Drawing.Abstractions.Test.Unit.Models.Shapes;
public class CircleTests
{
    [Fact]
    public void Initialize_HorizontalAndVerticalDiameter_When_Constructing()
    {
        var faker = new Faker();
        var diameter = faker.Random.Int(1, 100);

        var circle = new Circle(diameter);

        using var scope = new AssertionScope();
        circle.VerticalDiameter.Should().Be(diameter);
        circle.HorizontalDiameter.Should().Be(diameter);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Throw_ArgumentException_When_DiameterIsZeroOrLess(int diameter)
    {
        var action = () => new Circle(diameter);

        action.Should().Throw<ArgumentException>();
    }
}