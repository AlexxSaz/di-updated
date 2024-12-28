using System.Net;
using System.Text.Json;
using TagCloud.Infrastructure.Providers.Interfaces;
using TagCloud.Logic.CloudContainers;
using TagCloud.Readers;
using TagCloud.TagCloudPainters;
using TagCloudWebClient.JsonConverters;

namespace TagCloudWebClient.UiActions;

public class GetWordsAction(
    ITagCloudPainter tagCloudPainter,
    ITagCloud tagCloud,
    IImageSettingsProvider imageSettingsProvider,
    ILogicSettingsProvider logicSettingsProvider,
    IFileReader reader) : IApiAction
{
    private readonly JsonSerializerOptions _jsonSerializerOptions =
        new() { Converters = { new WordTagJsonConverter() } };

    public string Endpoint => "/getWords";

    public string HttpMethod => "POST";

    public int Perform(Stream inputStream, Stream outputStream)
    {
        var wordContainer = JsonSerializer.Deserialize<WordContainer>(inputStream);
        var words = reader.ReadFromString(wordContainer!.Words);
        var wordTags = tagCloud.GetTags(words);
        var imageSettings = imageSettingsProvider.GetImageSettings();
        var logicSettings = logicSettingsProvider.GetLogicSettings();

        var tagsInCloud = tagCloudPainter.PrintImage(wordTags, imageSettings, logicSettings);
        JsonSerializer.Serialize(outputStream, tagsInCloud, options: _jsonSerializerOptions);
        return (int)HttpStatusCode.OK;
    }
}