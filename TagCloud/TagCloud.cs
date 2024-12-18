using System.Drawing;
using TagCloud.CloudLayouts;
using TagCloud.Tags;

namespace TagCloud;

public class TagCloud : ITagCloud
{
    public List<ITag> Tags { get; set; } = new();
}