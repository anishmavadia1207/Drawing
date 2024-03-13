using System.Text.Json;

using Confluent.Kafka;

using Drawing.Abstractions.Constants;

using KafkaFlow;
using KafkaFlow.Configuration;

namespace Drawing.Producers.DI;

/// <summary>
/// Extension methods for IServiceCollection for adding Kafka producers related to drawing
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds Kafka producers for drawing
    /// </summary>
    /// <returns>The modified builder</returns>
    public static IClusterConfigurationBuilder AddDrawingKafkaProducers(
        this IClusterConfigurationBuilder @this
      ) =>
        @this
        .AddProducer<ShapeProducer>(producer =>
                    {
                        producer.DefaultTopic(KafkaKeys.ShapeTopicName);
                        producer.WithCompression(CompressionType.Gzip);
                        producer.AddMiddlewares(middleware => middleware.AddSerializer<Serializer>());
                    });

    internal class Serializer : ISerializer
    {
        public async Task SerializeAsync(object message, Stream output, ISerializerContext context) =>
            await JsonSerializer.SerializeAsync(output, message);
    }
}