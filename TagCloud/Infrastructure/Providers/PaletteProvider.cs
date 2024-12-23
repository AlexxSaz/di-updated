using System.Drawing;
using TagCloud.Infrastructure.Providers.Interfaces;

namespace TagCloud.Infrastructure.Providers;

public class PaletteProvider : IPaletteProvider
{
    private Palette _palette = new();

    public Palette GetPalette() =>
        _palette;

    public void SetFontColor(Color color) =>
        _palette = _palette with { FontColor = color };

    public void SetBackgroundColor(Color color) =>
        _palette = _palette with { BackgroundColor = color };
}