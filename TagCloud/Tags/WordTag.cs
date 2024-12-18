using System.Drawing;

namespace TagCloud.Tags;

public record WordTag(string Value, Font Font, Rectangle Frame) : ITag;
