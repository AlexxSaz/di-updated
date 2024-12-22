using System.Drawing;

namespace TagCloud.Infrastructure;

public abstract class Palette
{
    public Color PrimaryColor { get; set; } = Color.Black;
    public Color SecondaryColor { get; set; } = Color.Gold;
    public Color BackgroundColor { get; set; } = Color.Red;
}