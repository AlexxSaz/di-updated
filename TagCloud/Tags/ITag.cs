using System.Drawing;

namespace TagCloud.Tags;

public interface ITag
{
    Rectangle Frame { get; }
    string Value { get; }
    int FontSize { get; }
}