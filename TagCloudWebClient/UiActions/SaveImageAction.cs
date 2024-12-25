using System.Net;
using System.Text.Json;
using TagCloud.Infrastructure;
using TagCloud.Infrastructure.Providers.Interfaces;
using TagCloud.TagCloudPainters;

namespace TagCloudWebClient.UiActions;

public class SaveImageAction(
    ITagCloudPainter tagCloudPainter,
    IPaletteProvider paletteProvider,
    IImageSettingsProvider imageSettingsProvider,
    ILogicSettingsProvider logicSettingsProvider,
    SaveSettings saveSettings) : IApiAction
{
    public string Endpoint => "/saveImage";

    public string HttpMethod => "POST";

    public int Perform(Stream inputStream, Stream outputStream)
    {
        var palette = paletteProvider.GetPalette();
        var imageSettings = imageSettingsProvider.GetImageSettings();
        var logicSettings = logicSettingsProvider.GetLogicSettings();
        saveSettings.InputTxtFile = "";
        saveSettings.OutputPngFile = "";
        tagCloudPainter.SaveImage(imageSettings, palette, saveSettings, logicSettings);
        JsonSerializer.Serialize(outputStream, saveSettings.OutputPngFile);
        return (int)HttpStatusCode.OK;
    }
}