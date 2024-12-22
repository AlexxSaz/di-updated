using TagCloud.Logic.CloudLayouts;

namespace TagCloud.Infrastructure.Providers;

public class LogicSettingsProvider : ILogicSettingsProvider
{
    private LogicSettings _logicSettings = new();

    public LogicSettings GetLogicSettings() =>
        _logicSettings;

    public void SetRadiusStep(double radiusStep) =>
        _logicSettings = _logicSettings with { RadiusStep = radiusStep };

    public void SetAngleStep(double angleStep) =>
        _logicSettings = _logicSettings with { AngleStep = angleStep };

    public void SetCloudLayout(ICloudLayout cloudLayout) =>
        _logicSettings = _logicSettings with { CloudLayout = cloudLayout };
}