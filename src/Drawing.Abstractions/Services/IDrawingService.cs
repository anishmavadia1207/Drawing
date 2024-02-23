using Drawing.Abstractions.Models;


namespace Drawing.Abstractions.Services;
/// <summary>
/// Represents a service for drawing.
/// </summary>
public interface IDrawingService
{
    /// <summary>
    /// Draws the specified widgeted drawing and returns the result as a string.
    /// </summary>
    /// <param name="widgetedDrawing">The widgeted drawing to be rendered.</param>
    /// <returns>A string representing the drawing.</returns>
    public string Draw(WidgetedDrawing widgetedDrawing);
}