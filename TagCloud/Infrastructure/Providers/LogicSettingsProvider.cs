using System.Drawing;
using TagCloud.Infrastructure.Providers.Interfaces;

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
    
    public void SetCenterSize(Size centerSize) =>
        _logicSettings = _logicSettings with { Center = centerSize };
}