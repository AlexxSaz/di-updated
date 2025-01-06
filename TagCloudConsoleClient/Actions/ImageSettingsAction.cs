using TagCloud.Infrastructure;
using TagCloud.Infrastructure.Providers.Interfaces;
using TagCloudConsoleClient.Options;

namespace TagCloudConsoleClient.Actions;

public class ImageSettingsAction(IImageSettingsProvider imageSettingsProvider, ImageSettings imageSettings)
    : IConsoleAction
{
    public OptionType OptionType => OptionType.Image;

    public string Perform(IOption option)
    {
        var optionSettings = (ImageSettingsOption)option;
        var currentImageSettings = CreateImageSetting(optionSettings);
        imageSettingsProvider.SetImageSettings(currentImageSettings);
        return $"Настройки изображения изменены.\n" +
               $"Ширина {optionSettings.Width}, высота {optionSettings.Height}.\n" +
               $"Максимальный размер текста {optionSettings.MaxFontSize}, минимальный {optionSettings.MinFontSize}.\n" +
               $"Тип шрифта {optionSettings.FontFamily.Name}";
    }

    private ImageSettings CreateImageSetting(ImageSettingsOption imageSettingsOption) =>
        imageSettings with
        {
            FontFamily = imageSettingsOption.FontFamily,
            MaxFontSize = imageSettingsOption.MaxFontSize,
            MinFontSize = imageSettingsOption.MinFontSize,
            Width = imageSettingsOption.Width,
            Height = imageSettingsOption.Height
        };
}