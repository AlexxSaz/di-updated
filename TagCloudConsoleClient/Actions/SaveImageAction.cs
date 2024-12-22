using TagCloud.Infrastructure;
using TagCloud.Infrastructure.Providers;
using TagCloud.Logic.Containers;
using TagCloud.Readers;
using TagCloud.TagCloudPainters;
using TagCloud.WordHandlers;
using TagCloudConsoleClient.Options;

namespace TagCloudConsoleClient.Actions;

public class SaveImageAction(
    ITagCloudPainter tagCloudPainter,
    IImageSettingsProvider imageSettingsProvider,
    Palette palette,
    SaveSettings saveSettings,
    ILogicSettingsProvider logicSettingsProvider)
    : IConsoleAction
{
    public SettingsType SettingsType => SettingsType.Save;

    public string Perform(IOption iOption)
    {
        var optionSettings = (SaveImageOption)iOption;
        var imageSettings = imageSettingsProvider.GetImageSettings();
        var logicSettings = logicSettingsProvider.GetLogicSettings();
        saveSettings.InputTxtFile = optionSettings.InputTxtFile;
        saveSettings.OutputPngFile = optionSettings.OutputPngFile;
        tagCloudPainter.SaveImage(imageSettings, palette, saveSettings, logicSettings);
        return $"Картинка сохранена с именем {saveSettings.OutputPngFile}.";
    }
}