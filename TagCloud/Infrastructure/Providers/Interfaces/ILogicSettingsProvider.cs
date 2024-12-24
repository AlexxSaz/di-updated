using System.Drawing;
using TagCloud.Logic.PointGenerators;

namespace TagCloud.Infrastructure.Providers.Interfaces;

public interface ILogicSettingsProvider
{
    LogicSettings GetLogicSettings();
    void SetRadiusStep(double radiusStep);
    void SetAngleStep(double angleStep);
    void SetCenterSize(Size centerSize);
    void SetPointGenerator(PointGeneratorType pointGenerator);
}