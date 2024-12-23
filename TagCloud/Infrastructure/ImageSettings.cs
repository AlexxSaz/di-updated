using System.Drawing;

namespace TagCloud.Infrastructure;

public record ImageSettings
{
    public int Width { get; init; } = 800;
    public int Height { get; init; } = 600;
    public FontFamily FontFamily { get; init; } = new("Arial");
    public int MaxFontSize { get; init; } = 36;
    public int MinFontSize { get; init; } = 12;
}