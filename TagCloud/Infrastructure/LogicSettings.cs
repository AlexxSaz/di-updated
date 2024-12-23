using System.Drawing;

namespace TagCloud.Infrastructure;

public record LogicSettings
{
    public double RadiusStep { get; init; } = 0.01;
    public double AngleStep { get; init; } = 0.01;
    public Size Center { get; set; } = new();
}