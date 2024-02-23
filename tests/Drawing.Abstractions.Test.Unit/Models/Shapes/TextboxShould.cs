using Bogus;

using Drawing.Abstractions.Models.Shapes;

using FluentAssertions;
using FluentAssertions.Execution;

namespace Drawing.Abstractions.Test.Unit.Models.Shapes;
public class TextboxShould
{
    [Fact]
    public void Initialize_HeightWidthAndText_When_Constructing()
    {
        var faker = new Faker();
        var width = faker.Random.Int(1, 100);
        var height = faker.Random.Int(1, 100);
        var text = faker.Random.Words();

        var textbox = new Textbox(width, height, text);

        using var scope = new AssertionScope();
        textbox.Height.Should().Be(height);
        textbox.Width.Should().Be(width);
        textbox.Text.Should().Be(text);
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
        var faker = new Faker();
        var text = faker.Random.Words();

        var action = () => new Textbox(width, height, text);

        action.Should().Throw<ArgumentException>();
    }
}
