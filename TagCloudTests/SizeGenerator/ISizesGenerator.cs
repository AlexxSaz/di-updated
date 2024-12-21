using System.Drawing;

namespace TagCloudTests.SizeGenerator;

public interface ISizesGenerator
{
    public IEnumerable<Size> GenerateSize();
}