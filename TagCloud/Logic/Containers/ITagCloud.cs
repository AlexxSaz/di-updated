using TagCloud.Infrastructure.Tags;
using TagCloud.Logic.CloudLayouts;

namespace TagCloud.Logic.Containers;

public interface ITagCloud
{
    List<IWordTag> Tags { get; set; }
    ICloudLayout CloudLayout { get; }
    int Width { get; }
    int Height { get; }
}