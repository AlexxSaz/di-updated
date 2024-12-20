using System.Drawing;

namespace TagCloud.Tags;

public record WordTag(string Value, int FontSize, Rectangle Frame) : ITag
{
    public ITag SetFrame(Rectangle frame) => this with { Frame = frame };
}