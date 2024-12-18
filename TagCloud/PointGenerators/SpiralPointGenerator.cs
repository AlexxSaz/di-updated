using System.Drawing;
using TagCloud.Extensions;

namespace TagCloud.PointGenerators;

public class SpiralPointGenerator(AppConfig appConfig, Size centerPoint) : IPointGenerator
{
    public IEnumerable<Point> GeneratePoint()
    {
        var radius = 0d;
        var angle = 0d;

        while (true)
        {
            var newX = (int)(radius * Math.Cos(angle));
            var newY = (int)(radius * Math.Sin(angle));
            var newPoint = new Point(newX, newY).MoveTo(centerPoint);

            radius += appConfig.RadiusStep;
            angle += appConfig.AngleStep;

            yield return newPoint;
        }
        // ReSharper disable once IteratorNeverReturns
    }
}