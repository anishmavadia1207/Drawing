using Bogus;

using Drawing.Abstractions.Models.Shapes;

using FluentAssertions;
using FluentAssertions.Execution;

namespace Drawing.Abstractions.Test.Unit.Models.Shapes;
public class EllipseTests
{
    [Fact]
    public void Initialize_HorizontalAndVerticalDiameter_When_Constructing()
    {
        var faker = new Faker();
        var horizontalDiameter = faker.Random.Int(1, 100);
        var verticalDiameter = faker.Random.Int(1, 100);

        var ellipse = new Ellipse(horizontalDiameter, verticalDiameter);

        using var scope = new AssertionScope();
        ellipse.VerticalDiameter.Should().Be(verticalDiameter);
        ellipse.HorizontalDiameter.Should().Be(horizontalDiameter);
    }

    [Theory]
    [InlineData(0, 1)]
    [InlineData(-1, 1)]
    [InlineData(1, 0)]
    [InlineData(1, -1)]
    public void Throw_ArgumentException_When_DiameterIsZeroOrLess(
        int horizontalDiameter,
        int verticalDiameter)
    {
        var action = () => new Ellipse(horizontalDiameter, verticalDiameter);

        action.Should().Throw<ArgumentException>();
    }
}