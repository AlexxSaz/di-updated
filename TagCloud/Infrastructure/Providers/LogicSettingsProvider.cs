using System.Drawing;
using TagCloud.Infrastructure.Providers.Interfaces;
using TagCloud.Logic.PointGenerators;

namespace TagCloud.Infrastructure.Providers;

public class LogicSettingsProvider : ILogicSettingsProvider
{
    private LogicSettings _logicSettings = new();

    public LogicSettings GetLogicSettings() =>
        _logicSettings;

    public void SetLogicSettings(LogicSettings logicSettings) => _logicSettings = logicSettings;
}