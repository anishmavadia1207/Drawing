using Bogus;

using Drawing.Abstractions.Models;
using Drawing.Abstractions.Models.Shapes;
using Drawing.Abstractions.Models.Shapes.Base;

namespace Drawing.Test.Generators;
public static class TestGenerator
{
    public static Faker<Circle> CircleGenerator(int? diameter = null) =>
        new Faker<Circle>()
        .CustomInstantiator(f => new Circle(diameter ?? f.Random.Int(1, 100)));

    public static Faker<Ellipse> EllipseGenerator(
        int? horizontalDiameter = null,
        int? verticalDiameter = null) =>
        new Faker<Ellipse>()
        .CustomInstantiator(f => new Ellipse(
            horizontalDiameter ?? f.Random.Int(1, 100),
            verticalDiameter ?? f.Random.Int(1, 100)));

    public static Faker<Rectangle> RectangleGenerator(
        int? width = null,
        int? height = null) =>
        new Faker<Rectangle>()
        .CustomInstantiator(f => new Rectangle(
            width ?? f.Random.Int(1, 100),
            height ?? f.Random.Int(1, 100)));

    public static Faker<Square> SquareGenerator(int? width = null) =>
        new Faker<Square>()
        .CustomInstantiator(f => new Square(
            width ?? f.Random.Int(1, 100)));

    public static Faker<Textbox> TextboxGenerator(
        int? width = null,
        int? height = null,
        string? text = null) =>
        new Faker<Textbox>()
        .CustomInstantiator(f => new Textbox(
            width ?? f.Random.Int(1, 100),
            height ?? f.Random.Int(1, 100),
            text ?? f.Lorem.Sentence(5)));

    public static Faker<Position> PositionGenerator(
        int? x = null,
        int? y = null) =>
        new Faker<Position>()
        .CustomInstantiator(f => new Position(
            x ?? f.Random.Int(1, 100),
            y ?? f.Random.Int(1, 100)));

    public static Faker<Widget> WidgetGenerator(
        Position? position = null,
        IShape? shape = null) =>
        new Faker<Widget>()
        .CustomInstantiator(f =>
        new Widget(
            position ?? PositionGenerator().Generate(),
            shape ?? RectangleGenerator().Generate()));

    public static Faker<WidgetDrawing> WidgetDrawingGenerator(
        IEnumerable<Widget>? widgets = null) =>
        new Faker<WidgetDrawing>()
        .CustomInstantiator(f =>
        new WidgetDrawing(widgets ?? WidgetGenerator().Generate(10)));
}
