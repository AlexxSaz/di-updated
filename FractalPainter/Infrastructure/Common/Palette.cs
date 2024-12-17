using FractalPainting.Application.Models;

namespace FractalPainting.Infrastructure.Common;

public class Palette
{
    public Color PrimaryColor { get; set; } = new(255, 255, 0);
    public Color SecondaryColor { get; set; } = new(255, 0, 0);
    public Color BackgroundColor { get; set; } = new(0, 0, 139);
}