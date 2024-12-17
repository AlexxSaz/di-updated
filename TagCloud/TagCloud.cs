using System.Drawing;
using TagsCloudVisualization.Interfaces;

namespace TagCloud;

public class TagCloud(ICloudLayouter layout) : ITagCloud
{
    public List<Rectangle> Rectangles { get; } = [];
    private int _maxRight = 0;
    private int _maxBottom = 0;
    private int _minLeft = int.MaxValue;
    private int _minTop = int.MaxValue;

    public int Width =>
        Rectangles.Count == 0 ? 0 : _maxRight - _minLeft;

    public int Height =>
        Rectangles.Count == 0 ? 0 : _maxBottom - _minTop;

    public int LeftBound =>
        _minLeft;

    public int TopBound =>
        _minTop;

    public void AddNextRectangleWith(Size size)
    {
        var nextRectangle = layout.PutNextRectangle(size);
        _maxRight = Math.Max(_maxRight, nextRectangle.Right);
        _maxBottom = Math.Max(_maxBottom, nextRectangle.Bottom);
        _minLeft = Math.Min(_minLeft, nextRectangle.Left);
        _minTop = Math.Min(_minTop, nextRectangle.Top);
        Rectangles.Add(nextRectangle);
    }
}