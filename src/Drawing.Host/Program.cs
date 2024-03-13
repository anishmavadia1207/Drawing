using Drawing.Abstractions.Constants;
using Drawing.Abstractions.Services.Producers;
using Drawing.Consumer.DI;
using Drawing.Core.DI;
using Drawing.Producers;
using Drawing.Producers.DI;

using KafkaFlow;

using Microsoft.Extensions.DependencyInjection;

namespace Drawing.Host;

internal class Program
{
    const string dashedSeparator = "----------------------------------------------------------------";
    static async Task Main(string[] args)
    {
        var services = new ServiceCollection();
        services.AddCoreDrawingServices()
                .AddKafka(kafka =>
                    kafka
                    .AddCluster(cluster => cluster
                            .WithBrokers(["localhost:9092"])
                            .CreateTopicIfNotExists(KafkaKeys.ShapeTopicName, 1, 1)
                            .AddDrawingKafkaConsumers()
                            .AddDrawingKafkaProducers()))
                .AddScoped<IShapeProducer, ShapeProducer>();

        var provider = services.BuildServiceProvider();

        var bus = provider.CreateKafkaBus();
        await bus.StartAsync();

        var producer = provider.GetRequiredService<IShapeProducer>();

        while (true)
        {
            var input = Console.ReadLine();

            if (input == "x")
            {
                await bus.StopAsync();
                break;
            }

            await producer.ProduceAsync();
        }
    }
}
