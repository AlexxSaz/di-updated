using System.Drawing;

namespace TagCloud.Infrastructure;

public class ImageSettings()
{
    public int Width { get; set; } = 800;
    public int Height { get; set; } = 600;
    public FontFamily FontFamily { get; set; } = new("Arial");
    public string Filename { get; set; } = "TagCloud.png";
}