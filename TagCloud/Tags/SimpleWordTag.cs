using System.Drawing;

namespace TagCloud.Tags;

public record SimpleWordTag(string Value, int FontSize) : IWordTag;