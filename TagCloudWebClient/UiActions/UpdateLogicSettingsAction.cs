using System.Net;
using System.Text.Json;
using TagCloud.Infrastructure;
using TagCloud.Infrastructure.Providers.Interfaces;
using TagCloud.Logic.PointGenerators;
using TagCloudWebClient.JsonConverters;

namespace TagCloudWebClient.UiActions;

public class UpdateLogicSettingsAction(ILogicSettingsProvider logicSettingsProvider) : IApiAction
{
    private readonly JsonSerializerOptions _jsonSerializerOptions =
        new() { Converters = { new PointGeneratorTypeConverter() } };

    public string Endpoint => "/logic";
    public string HttpMethod => "PUT";

    public int Perform(Stream inputStream, Stream outputStream)
    {
        var updatedSettings = JsonSerializer.Deserialize<LogicSettings>(inputStream, options: _jsonSerializerOptions);
        logicSettingsProvider.SetAngleStep(updatedSettings?.AngleStep ?? 0.01);
        logicSettingsProvider.SetRadiusStep(updatedSettings?.RadiusStep ?? 0.01);
        logicSettingsProvider.SetPointGenerator(updatedSettings?.PointGeneratorType ?? PointGeneratorType.Spiral);
        var settings = logicSettingsProvider.GetLogicSettings();
        JsonSerializer.Serialize(outputStream, settings, options: _jsonSerializerOptions);

        return (int)HttpStatusCode.OK;
    }
}