using Drawing.Abstractions.Messages;
using Drawing.Abstractions.Services.Producers;

using KafkaFlow;

namespace Drawing.Producers;
public class ShapeProducer : IShapeProducer
{
    private readonly IMessageProducer<ShapeProducer> _messageProducer;

    public ShapeProducer(IMessageProducer<ShapeProducer> messageProducer) =>
        _messageProducer = messageProducer;

    /// <inheritdoc/>
    public Task ProduceAsync() =>
        _messageProducer.ProduceAsync(Guid.NewGuid().ToString(), new CreateShapeMessage());

}
