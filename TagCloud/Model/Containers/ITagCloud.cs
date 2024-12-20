using System.Drawing;
using TagCloud.CloudLayouts;
using TagCloud.Tags;

namespace TagCloud;

public interface ITagCloud
{
    List<ITag> Tags { get; set; }
    ICloudLayout CloudLayout { get; }
    int Width { get; }
    int Height { get; }
}