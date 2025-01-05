using System.Drawing;
using TagCloud.Logic.PointGenerators;

namespace TagCloud.Infrastructure.Providers.Interfaces;

public interface ILogicSettingsProvider
{
    LogicSettings GetLogicSettings();
    void SetLogicSettings(LogicSettings logicSettings);
}