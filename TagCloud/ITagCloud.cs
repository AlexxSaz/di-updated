using System.Drawing;
using TagCloud.Tags;

namespace TagCloud;

public interface ITagCloud
{
    List<ITag> Tags { get; set; }
}