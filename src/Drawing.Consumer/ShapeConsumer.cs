using Drawing.Abstractions.Messages;

using KafkaFlow;

namespace Drawing.Consumer;
public class ShapeConsumer : IMessageHandler<CreateShapeMessage>
{
    public Task Handle(IMessageContext context, CreateShapeMessage message)
    {
        Console.WriteLine("Received create shape message");
        return Task.CompletedTask;
    }
}
