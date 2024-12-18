using System.Drawing;
using TagCloud.CloudLayouts;
using TagCloud.Tags;

namespace TagCloud;

public class TagCloud<TTag>(ICloudLayout layout) : ITagCloud
{
    private int _maxRight = 0;
    private int _maxBottom = 0;
    private int _minLeft = int.MaxValue;
    private int _minTop = int.MaxValue;

    public int Width =>
        _maxRight == 0 ? 0 : _maxRight - _minLeft;

    public int Height =>
        _maxRight == 0 ? 0 : _maxBottom - _minTop;

    public int LeftBound =>
        _minLeft;

    public int TopBound =>
        _minTop;

    public void SetNewSize(Rectangle frame)
    {
        _maxRight = Math.Max(_maxRight, frame.Right);
        _maxBottom = Math.Max(_maxBottom, frame.Bottom);
        _minLeft = Math.Min(_minLeft, frame.Left);
        _minTop = Math.Min(_minTop, frame.Top);
    }
}