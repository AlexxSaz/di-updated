using FractalPainting.Application.Fractals;

namespace FractalPainting.Infrastructure.Common;

public class DragonPainterFactory(IImageSettingsProvider imageSettingsProvider, Palette palette) : IDragonPainterFactory
{
    private readonly IImageSettingsProvider imageSettingsProvider = imageSettingsProvider;

    public DragonPainter Create(DragonSettings settings) =>
        new DragonPainter(palette, settings, imageSettingsProvider);
}