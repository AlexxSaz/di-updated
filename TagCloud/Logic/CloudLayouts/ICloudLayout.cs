using System.Drawing;
using TagCloud.Calculators;
using TagCloud.Infrastructure.Tags;
using TagCloud.WordHandlers;

namespace TagCloud.Logic.CloudLayouts;

public interface ICloudLayout
{
    List<IWordTag> GetTags(IEnumerable<string> words, IWordHandler wordHandler, ISizeCalculator sizeCalculator);
    public Rectangle PutNextRectangle(Size rectangleSize);
}