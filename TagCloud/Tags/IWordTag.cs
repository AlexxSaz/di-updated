using System.Drawing;

namespace TagCloud.Tags;

public interface IWordTag
{
    string Value { get; }
    int FontSize { get; }
}