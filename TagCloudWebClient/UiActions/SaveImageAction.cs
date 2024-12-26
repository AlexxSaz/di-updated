using System.Net;
using System.Text.Json;
using TagCloud.Infrastructure;
using TagCloud.Infrastructure.Providers.Interfaces;
using TagCloud.Readers;
using TagCloud.TagCloudPainters;

namespace TagCloudWebClient.UiActions;

public class SaveImageAction(
    ITagCloudPainter tagCloudPainter,
    IImageSettingsProvider imageSettingsProvider,
    ILogicSettingsProvider logicSettingsProvider,
    IFileReader reader) : IApiAction
{
    public string Endpoint => "/saveImage";

    public string HttpMethod => "POST";

    public int Perform(Stream inputStream, Stream outputStream)
    {
        var words = reader.Read(inputStream);
        var imageSettings = imageSettingsProvider.GetImageSettings();
        var logicSettings = logicSettingsProvider.GetLogicSettings();

        var tagsInCloud = tagCloudPainter.PrintImage(words, imageSettings, logicSettings);
        JsonSerializer.Serialize(outputStream, tagsInCloud);
        return (int)HttpStatusCode.OK;
    }
}