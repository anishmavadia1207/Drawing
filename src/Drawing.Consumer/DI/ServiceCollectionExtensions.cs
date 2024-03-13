using System.Text.Json;

using Drawing.Abstractions.Constants;

using KafkaFlow;
using KafkaFlow.Configuration;

namespace Drawing.Consumer.DI;

/// <summary>
/// Extension methods for IServiceCollection for adding Kafka consumers related to drawing
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds Kafka consumers for drawing
    /// </summary>
    /// <param name="kafkaClusterUrl">The Kafka cluster URL</param>
    /// <param name="kafkaUsername">The Kafka username</param>
    /// <param name="kafkaPassword">The Kafka password</param>
    /// <returns>The modified IServiceCollection</returns>
    public static IClusterConfigurationBuilder AddDrawingKafkaConsumers(this IClusterConfigurationBuilder @this) =>
        @this.AddConsumer(consumer => consumer
                        .Topic(KafkaKeys.ShapeTopicName)
                        .WithGroupId(Guid.NewGuid().ToString())
                        .WithBufferSize(1)
                        .WithWorkersCount(1)
                        .AddMiddlewares(middleware => middleware
                            .AddDeserializer<Serializer>()
                            .AddTypedHandlers(handlers => handlers.AddHandler<ShapeConsumer>())));
}

internal class Serializer : IDeserializer
{
    public async Task<object> DeserializeAsync(Stream input, Type type, ISerializerContext context) =>
        await JsonSerializer.DeserializeAsync(input, type) ?? throw new InvalidOperationException();
}