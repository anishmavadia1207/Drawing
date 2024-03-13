/// <summary>
/// Represents the interface for a shape producer.
/// </summary>
namespace Drawing.Abstractions.Services.Producers;
public interface IShapeProducer
{
    /// <summary>
    /// Produces a shape and pushed it to the default topic.
    /// </summary>
    /// <returns>A task representing an async operation.</returns>
    Task ProduceAsync();
}