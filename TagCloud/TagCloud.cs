using System.Drawing;
using TagCloud.CloudLayouts;
using TagCloud.Tags;

namespace TagCloud;

public class TagCloud(AppConfig appConfig) : ITagCloud
{
    public List<ITag> Tags { get; set; } = new();
    
    public int Width => appConfig.Width;
    public int Height => appConfig.Height;
}