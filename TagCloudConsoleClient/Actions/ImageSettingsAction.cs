using System.Drawing;
using TagCloud.Infrastructure.Providers.Interfaces;
using TagCloudConsoleClient.Options;

namespace TagCloudConsoleClient.Actions;

public class ImageSettingsAction(IImageSettingsProvider imageSettingsProvider) : IConsoleAction
{
    public OptionType OptionType => OptionType.Image;

    public string Perform(IOption option)
    {
        var optionSettings = (ImageSettingsOption)option;
        var fontFamily = GetFontFamily(optionSettings.FontFamily);
        imageSettingsProvider.SetWidth(optionSettings.Width);
        imageSettingsProvider.SetHeight(optionSettings.Height);
        imageSettingsProvider.SetFontFamily(fontFamily);
        imageSettingsProvider.SetMaxFontSize(optionSettings.MaxFontSize);
        imageSettingsProvider.SetMinFontSize(optionSettings.MinFontSize);
        return $"Настройки изображения изменены.{Environment.NewLine}" +
               $"Ширина {optionSettings.Width}, высота {optionSettings.Height}.{Environment.NewLine}" +
               $"Максимальный размер текста {optionSettings.MaxFontSize}, минимальный {optionSettings.MinFontSize}.{Environment.NewLine}" +
               $"Тип шрифта {fontFamily.Name}";
    }

    private FontFamily GetFontFamily(byte optionSettingsFontFamily) =>
        optionSettingsFontFamily switch
        {
            1 => new FontFamily("Arial"),
            2 => new FontFamily("Times New Roman"),
            3 => new FontFamily("Georgia"),
            4 => new FontFamily("Calibri"),
            5 => new FontFamily("Bahnschrift"),
            6 => new FontFamily("Courier New"),
            _ => new FontFamily("Arial")
        };
}