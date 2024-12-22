using System.Drawing;
using TagCloud.Logic.CloudLayouts;

namespace TagCloud.Infrastructure.Providers;

public interface IImageSettingsProvider
{
    ImageSettings GetImageSettings();
    void SetWidth(int width);
    void SetHeight(int height);
    void SetFontFamily(FontFamily fontFamily);
}