using System.Drawing;

namespace TagCloud.Infrastructure.Providers.Interfaces;

public interface ILogicSettingsProvider
{
    LogicSettings GetLogicSettings();
    void SetRadiusStep(double radiusStep);
    void SetAngleStep(double angleStep);
    void SetCenterSize(Size centerSize);
}