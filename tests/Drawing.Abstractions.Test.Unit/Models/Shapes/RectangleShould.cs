using Bogus;

using Drawing.Abstractions.Models.Shapes;

using FluentAssertions;
using FluentAssertions.Execution;

namespace Drawing.Abstractions.Test.Unit.Models.Shapes;
public class RectangleShould
{
    [Fact]
    public void Initialize_HeightAndWidth_When_Constructing()
    {
        var faker = new Faker();
        var width = faker.Random.Int(1, 100);
        var height = faker.Random.Int(1, 100);

        var rectangle = new Rectangle(width, height);

        using var scope = new AssertionScope();
        rectangle.Height.Should().Be(height);
        rectangle.Width.Should().Be(width);
    }

    [Theory]
    [InlineData(0, 1)]
    [InlineData(-1, 1)]
    [InlineData(1, 0)]
    [InlineData(1, -1)]
    public void Throw_ArgumentException_When_WidthOrHeightIsZeroOrLess(
        int width,
        int height)
    {
        var action = () => new Rectangle(width, height);

        action.Should().Throw<ArgumentException>();
    }
}
