using System.Drawing;
using System.Net;
using System.Text.Json;
using TagCloud.Infrastructure;
using TagCloud.Infrastructure.Providers.Interfaces;
using TagCloudWebClient.JsonConverters;

namespace TagCloudWebClient.UiActions;

public class UpdateImageSettingsAction(IImageSettingsProvider imageSettingsProvider) : IApiAction
{
    public string Endpoint => "/settings";
    public string HttpMethod => "PUT";

    public int Perform(Stream inputStream, Stream outputStream)
    {
        var updatedSettings = JsonSerializer.Deserialize<ImageSettings>(inputStream,
            new JsonSerializerOptions { Converters = { new FontFamilyJsonConverter() } });
        imageSettingsProvider.SetWidth(updatedSettings?.Width ?? 1000);
        imageSettingsProvider.SetHeight(updatedSettings?.Height ?? 1000);
        imageSettingsProvider.SetFontFamily(updatedSettings?.FontFamily ?? new FontFamily("Arial"));
        imageSettingsProvider.SetMaxFontSize(updatedSettings?.MaxFontSize ?? 24);
        imageSettingsProvider.SetMinFontSize(updatedSettings?.MinFontSize ?? 8);
        var settings = imageSettingsProvider.GetImageSettings();
        JsonSerializer.Serialize(outputStream, settings);

        return (int)HttpStatusCode.OK;
    }
}