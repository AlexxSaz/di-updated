using TagCloud.Logic.CloudLayouts;

namespace TagCloud.Infrastructure.Providers;

public interface ILogicSettingsProvider
{
    LogicSettings GetLogicSettings();
    void SetRadiusStep(double radiusStep);
    void SetAngleStep(double angleStep);
    void SetCloudLayout(ICloudLayout cloudLayout);
}