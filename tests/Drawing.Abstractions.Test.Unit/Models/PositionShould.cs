using Bogus;

using Drawing.Abstractions.Models;

using FluentAssertions;
using FluentAssertions.Execution;

namespace Drawing.Abstractions.Test.Unit.Models;
public class PositionShould
{
    [Fact]
    public void Initialise_XandY_When_Constructing()
    {
        var faker = new Faker();
        var x = faker.Random.Int();
        var y = faker.Random.Int();

        var position = new Position(x, y);

        using var scope = new AssertionScope();
        position.X.Should().Be(x);
        position.Y.Should().Be(y);
    }
}