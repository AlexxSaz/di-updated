using TagCloud.Infrastructure;
using TagCloud.Infrastructure.Providers;
using TagCloud.Logic.Containers;
using TagCloudConsoleClient.Options;

namespace TagCloudConsoleClient.Actions;

public class ImageSettingsAction(IImageSettingsProvider imageSettingsProvider) : IConsoleAction
{
    public SettingsType SettingsType => SettingsType.Image;

    public string Perform(IOption iOption)
    {
        var optionSettings = (ImageSettingsOption)iOption;
        imageSettingsProvider.SetWidth(optionSettings.Width);
        imageSettingsProvider.SetHeight(optionSettings.Height);
        return $"Настройки изображения изменены. Ширина {optionSettings.Width}, высота {optionSettings.Height}.";
    }
}