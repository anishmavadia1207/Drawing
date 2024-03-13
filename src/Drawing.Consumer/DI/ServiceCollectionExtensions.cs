using Drawing.Abstractions.Constants;

using KafkaFlow;

using Microsoft.Extensions.DependencyInjection;

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
    public static IServiceCollection AddDrawingKafkaProducers(
        this IServiceCollection @this,
        string kafkaClusterUrl,
        string kafkaUsername,
        string kafkaPassword) =>
        @this
        .AddKafka(kafka =>
            kafka.AddCluster(cluster => cluster
                    .WithBrokers([kafkaClusterUrl])
                    .WithSecurityInformation(security =>
                    {
                        security.SaslUsername = kafkaUsername;
                        security.SaslPassword = kafkaPassword;
                    })
                    .CreateTopicIfNotExists(KafkaKeys.ShapeTopicName, 1, 1)));
}