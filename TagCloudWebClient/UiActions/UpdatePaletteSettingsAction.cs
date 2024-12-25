using System.Drawing;
using System.Net;
using System.Text.Json;
using TagCloud.Infrastructure;
using TagCloud.Infrastructure.Providers.Interfaces;
using TagCloudWebClient.JsonConverters;

namespace TagCloudWebClient.UiActions;

public class UpdatePaletteSettingsAction(IPaletteProvider paletteProvider) : IApiAction
{
    public string Endpoint => "/palette";

    public string HttpMethod => "PUT";

    public int Perform(Stream inputStream, Stream outputStream)
    {
        var updatedPalette = JsonSerializer.Deserialize<Palette>(inputStream,
            new JsonSerializerOptions { Converters = { new ColorJsonConverter() } });
        paletteProvider.SetFontColor(updatedPalette?.FontColor ?? Color.Black);
        paletteProvider.SetBackgroundColor(updatedPalette?.BackgroundColor ?? Color.Wheat);
        var palette = paletteProvider.GetPalette();
        JsonSerializer.Serialize(outputStream, palette);

        return (int)HttpStatusCode.OK;
    }
}