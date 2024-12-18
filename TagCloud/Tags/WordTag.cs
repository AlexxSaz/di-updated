using System.Drawing;
using TagCloud.Extensions;

namespace TagCloud.Tags;

public record WordTag(string Value, int FontSize, Rectangle Frame) : ITag;