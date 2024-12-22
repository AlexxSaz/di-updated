using System.Drawing;
using TagCloud.Extensions;
using TagCloud.Infrastructure;

namespace TagCloud.Logic.PointGenerators;

public class SpiralPointGenerator(LogicSettings logicSettings) : IPointGenerator
{
    private readonly Size _centerPointSize = new(logicSettings.Center);

    public IEnumerable<Point> GeneratePoint()
    {
        var radius = 0d;
        var angle = 0d;

        while (true)
        {
            var newX = (int)(radius * Math.Cos(angle));
            var newY = (int)(radius * Math.Sin(angle));
            var newPoint = new Point(newX, newY).MoveTo(_centerPointSize);

            radius += logicSettings.RadiusStep;
            angle += logicSettings.AngleStep;

            yield return newPoint;
        }
        // ReSharper disable once IteratorNeverReturns
    }
}