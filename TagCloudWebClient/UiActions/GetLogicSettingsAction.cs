using System.Net;
using System.Text.Json;
using TagCloud.Infrastructure.Providers.Interfaces;
using TagCloudWebClient.JsonConverters;

namespace TagCloudWebClient.UiActions;

public class GetLogicSettingsAction(ILogicSettingsProvider logicSettingsProvider) : IApiAction
{
    public string Endpoint => "/logic";

    public string HttpMethod => "GET";

    public int Perform(Stream inputStream, Stream outputStream)
    {
        var settings = logicSettingsProvider.GetLogicSettings();
        JsonSerializer.Serialize(outputStream, settings,
            new JsonSerializerOptions { Converters = { new PointGeneratorTypeConverter() } });
        return (int)HttpStatusCode.OK;
    }
}