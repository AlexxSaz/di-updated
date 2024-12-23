using TagCloud.Infrastructure;
using TagCloud.Infrastructure.Providers;
using TagCloud.Infrastructure.Providers.Interfaces;
using TagCloud.TagCloudPainters;
using TagCloudConsoleClient.Options;

namespace TagCloudConsoleClient.Actions;

public class SaveImageAction(
    ITagCloudPainter tagCloudPainter,
    IImageSettingsProvider imageSettingsProvider,
    IPaletteProvider paletteProvider,
    SaveSettings saveSettings,
    ILogicSettingsProvider logicSettingsProvider)
    : IConsoleAction
{
    public SettingsType SettingsType => SettingsType.Save;

    public string Perform(IOption option)
    {
        var optionSettings = (SaveImageOption)option;
        var imageSettings = imageSettingsProvider.GetImageSettings();
        var palette = paletteProvider.GetPalette();
        var logicSettings = logicSettingsProvider.GetLogicSettings();
        saveSettings.InputTxtFile = optionSettings.InputTxtFile;
        saveSettings.OutputPngFile = optionSettings.OutputPngFile;
        tagCloudPainter.SaveImage(imageSettings, palette, saveSettings, logicSettings);
        return $"Картинка сохранена с именем {saveSettings.OutputPngFile}.";
    }
}