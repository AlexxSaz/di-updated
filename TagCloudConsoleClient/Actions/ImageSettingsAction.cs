using TagCloud.Infrastructure.Providers.Interfaces;
using TagCloudConsoleClient.Options;

namespace TagCloudConsoleClient.Actions;

public class ImageSettingsAction(IImageSettingsProvider imageSettingsProvider) : IConsoleAction
{
    public SettingsType SettingsType => SettingsType.Image;

    public string Perform(IOption option)
    {
        var optionSettings = (ImageSettingsOption)option;
        imageSettingsProvider.SetWidth(optionSettings.Width);
        imageSettingsProvider.SetHeight(optionSettings.Height);
        return $"Настройки изображения изменены. Ширина {optionSettings.Width}, высота {optionSettings.Height}.";
    }
}