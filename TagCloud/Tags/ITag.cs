using System.Drawing;

namespace TagCloud.Tags;

public interface ITag
{
    Rectangle Frame { get; }
}