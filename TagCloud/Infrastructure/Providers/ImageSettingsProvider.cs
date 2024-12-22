using System.Drawing;
using TagCloud.Logic.CloudLayouts;

namespace TagCloud.Infrastructure.Providers;

public class ImageSettingsProvider : IImageSettingsProvider
{
    private ImageSettings _imageSettings = new();

    public ImageSettings GetImageSettings() => _imageSettings;

    public void SetWidth(int width) =>
        _imageSettings = _imageSettings with { Width = width };

    public void SetHeight(int height) =>
        _imageSettings = _imageSettings with { Height = height };

    public void SetFontFamily(FontFamily fontFamily) =>
        _imageSettings = _imageSettings with { FontFamily = fontFamily };
}