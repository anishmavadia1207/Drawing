using Drawing.Producers.Constants;

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
        @this.AddKafka(kafka =>
            kafka.AddCluster(cluster => cluster
                .WithBrokers([kafkaClusterUrl])
                .WithSecurityInformation(security =>
                {
                    security.SaslUsername = kafkaUsername;
                    security.SaslPassword = kafkaPassword;
                })
                .CreateTopicIfNotExists(KafkaKeys.ShapeTopicName, 1, 1)));
}