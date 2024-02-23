using Bogus;

using Drawing.Abstractions.Models.Shapes;

using FluentAssertions;
using FluentAssertions.Execution;

namespace Drawing.Abstractions.Test.Unit.Models.Shapes;
public class SquareShould
{
    [Fact]
    public void Initialize_HeightAndWidth_When_Constructing()
    {
        var faker = new Faker();
        var width = faker.Random.Int(1, 100);

        var rectangle = new Square(width);

        using var scope = new AssertionScope();
        rectangle.Height.Should().Be(width);
        rectangle.Width.Should().Be(width);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Throw_ArgumentException_When_WidthIsZeroOrLess(int width)
    {
        var action = () => new Square(width);

        action.Should().Throw<ArgumentException>();
    }
}
