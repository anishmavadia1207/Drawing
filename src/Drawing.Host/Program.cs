using Drawing.Abstractions.Models;
using Drawing.Abstractions.Models.Shapes;
using Drawing.Abstractions.Services;
using Drawing.Abstractions.Services.Builders;
using Drawing.Core.DI;

using Microsoft.Extensions.DependencyInjection;

namespace Drawing.Host;

internal class Program
{
    static void Main(string[] args)
    {
        var services = new ServiceCollection();
        services.AddCoreDrawingServices();

        var provider = services.BuildServiceProvider();
        var drawingService = provider.GetRequiredService<IDrawingService>();

        var builder = provider.GetRequiredService<IWidgetDrawingBuilder>();
        builder
            .AddWidget(new Widget(new Position(10, 10), new Rectangle(30, 40)))
            .AddWidget(new Widget(new Position(100, 150), new Ellipse(300, 200)))
            .AddWidget(new Widget(new Position(1, 1), new Circle(300)))
            .AddWidget(new Widget(new Position(5, 5), new Textbox(200, 100, "sample text")));

        var drawing = builder.Build();
        var drawingResult = drawingService.Draw(drawing);

        Console.WriteLine(drawingResult);
    }
}
