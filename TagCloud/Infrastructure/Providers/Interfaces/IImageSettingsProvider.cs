using System.Drawing;

namespace TagCloud.Infrastructure.Providers.Interfaces;

public interface IImageSettingsProvider
{
    ImageSettings GetImageSettings();
    void SetWidth(int width);
    void SetHeight(int height);
    void SetFontFamily(FontFamily fontFamily);
}