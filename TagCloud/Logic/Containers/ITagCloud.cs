using TagCloud.Logic.CloudLayouts;
using TagCloud.Tags;

namespace TagCloud.Logic.Containers;

public interface ITagCloud
{
    List<ITag> Tags { get; set; }
    ICloudLayout CloudLayout { get; }
    int Width { get; }
    int Height { get; }
}