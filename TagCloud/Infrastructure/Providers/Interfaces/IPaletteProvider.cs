using System.Drawing;

namespace TagCloud.Infrastructure.Providers.Interfaces;

public interface IPaletteProvider
{
    Palette GetPalette();
    void SetFontColor(Color color);
    void SetBackgroundColor(Color color);
}