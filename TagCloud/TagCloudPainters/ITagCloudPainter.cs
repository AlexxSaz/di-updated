using TagCloud.Infrastructure;

namespace TagCloud.TagCloudPainters;

public interface ITagCloudPainter
{
    void SaveImage(
        ImageSettings imageSettings,
        Palette palette,
        SaveSettings saveSettings,
        LogicSettings logicSettings);
}