using Drawing.Abstractions.Models;
using Drawing.Abstractions.Services.Renderer;
using Drawing.Core.Services;
using Drawing.Test.Generators;

using FluentAssertions.Execution;

using NSubstitute;

namespace Drawing.Core.Test.Unit.Services;
public class DrawingServiceTests
{
    private readonly DrawingService _service;
    private readonly IWidgetRenderer _rendererSubstitute;
    public DrawingServiceTests()
    {
        _rendererSubstitute = Substitute.For<IWidgetRenderer>();
        _service = new DrawingService(_rendererSubstitute);
    }

    [Fact]
    public void Call_RendererForEachWidget_When_Rendering()
    {
        var widgets = TestGenerator.WidgetDrawingGenerator().Generate();

        _ = _service.Draw(widgets);

        using var scope = new AssertionScope();
        _rendererSubstitute
            .Received(widgets.Widgets.Count())
            .Render(Arg.Any<Widget>());
    }
}