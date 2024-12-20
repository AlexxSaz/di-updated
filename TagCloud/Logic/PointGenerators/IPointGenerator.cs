using System.Drawing;

namespace TagCloud.Logic.PointGenerators;

public interface IPointGenerator
{
    public IEnumerable<Point> GeneratePoint();
}