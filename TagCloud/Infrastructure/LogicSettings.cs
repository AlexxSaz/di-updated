using System.Drawing;

namespace TagCloud.Infrastructure;

public class LogicSettings
{
    public double RadiusStep { get; set; } = 0.01;
    public double AngleStep { get; set; } = 0.01;
    public Point Center { get; set; } = new();
}