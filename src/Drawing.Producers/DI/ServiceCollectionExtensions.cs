﻿using System.Text.Json;

using Confluent.Kafka;

using Drawing.Abstractions.Constants;
using Drawing.Abstractions.Services.Producers;

using KafkaFlow;

using Microsoft.Extensions.DependencyInjection;

namespace Drawing.Producers.DI;

/// <summary>
/// Extension methods for IServiceCollection for adding Kafka producers related to drawing
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds Kafka producers for drawing
    /// </summary>
    /// <param name="kafkaClusterUrl">The Kafka cluster URL</param>
    /// <param name="kafkaUsername">The Kafka username</param>
    /// <param name="kafkaPassword">The Kafka password</param>
    /// <returns>The modified IServiceCollection</returns>
    public static IServiceCollection AddDrawingKafkaProducers(
        this IServiceCollection @this,
        string kafkaClusterUrl,
        string kafkaUsername,
        string kafkaPassword) =>
        @this
        .AddKafka(kafka =>
            kafka.AddCluster(cluster => cluster
                    .WithBrokers([kafkaClusterUrl])
                    .AddProducer<ShapeProducer>(producer =>
                    {
                        producer.DefaultTopic(KafkaKeys.ShapeTopicName);
                        producer.WithCompression(CompressionType.Gzip);
                        producer.AddMiddlewares(middleware => middleware.AddSerializer(_ => new Serializer()));
                    })
                    .CreateTopicIfNotExists(KafkaKeys.ShapeTopicName, 1, 1)))
        .AddScoped<IShapeProducer, ShapeProducer>();
}

internal class Serializer : ISerializer
{
    public async Task SerializeAsync(object message, Stream output, ISerializerContext context) =>
        await JsonSerializer.SerializeAsync(output, message);
}