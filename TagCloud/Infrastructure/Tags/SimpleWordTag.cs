using System.Drawing;

namespace TagCloud.Infrastructure.Tags;

public record SimpleWordTag(string Value, Font Font, Point Location) : IWordTag;