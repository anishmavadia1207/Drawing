using Drawing.Abstractions.Models.Shapes.Base;

namespace Drawing.Abstractions.Models.Shapes;

/// <summary>
/// Represents a textbox, inheriting from <see cref="RectangularShape"/>.
/// </summary>
public class Textbox : RectangularShape
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Textbox"/> class with the specified width, height, and text.
    /// </summary>
    /// <param name="width">The width of the textbox.</param>
    /// <param name="height">The height of the textbox.</param>
    /// <param name="text">The text content of the textbox.</param>
    public Textbox(int width, int height, string text) :
        base(width, height) =>
        Text = text;

    /// <summary>
    /// Gets the text content of the textbox.
    /// </summary>
    public string Text { get; }
}
