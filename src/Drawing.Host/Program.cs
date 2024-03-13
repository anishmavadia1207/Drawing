using Drawing.Abstractions.Models;
using Drawing.Abstractions.Models.Shapes;
using Drawing.Abstractions.Services;
using Drawing.Abstractions.Services.Builders;
using Drawing.Abstractions.Services.Producers;
using Drawing.Consumer.DI;
using Drawing.Core.DI;
using Drawing.Producers.DI;

using Microsoft.Extensions.DependencyInjection;

namespace Drawing.Host;

internal class Program
{
    const string dashedSeparator = "----------------------------------------------------------------";
    static void Main(string[] args)
    {
        var services = new ServiceCollection();
        services.AddCoreDrawingServices()
            .AddDrawingKafkaConsumers("localhost:9092", "", "")
            .AddDrawingKafkaProducers("localhost:9092", "", "");

        var provider = services.BuildServiceProvider();
        var drawingService = provider.GetRequiredService<IDrawingService>();

        var builder = provider.GetRequiredService<IWidgetDrawingBuilder>();
        builder
            .AddWidget(new Widget(new Position(10, 10), new Rectangle(30, 40)))
            .AddWidget(new Widget(new Position(15, 30), new Square(35)))
            .AddWidget(new Widget(new Position(100, 150), new Ellipse(300, 200)))
            .AddWidget(new Widget(new Position(1, 1), new Circle(300)))
            .AddWidget(new Widget(new Position(5, 5), new Textbox(200, 100, "sample text")));

        var producer = provider.GetRequiredService<IShapeProducer>();
        producer.ProduceAsync().GetAwaiter().GetResult();

        var drawing = builder.Build();
        var drawingResult = drawingService.Draw(drawing);

        Console.WriteLine(dashedSeparator);
        Console.WriteLine("Requested Drawing");
        Console.WriteLine(dashedSeparator);
        Console.WriteLine(drawingResult);
        Console.WriteLine(dashedSeparator);

        Console.ReadKey();
    }
}
