using System.Drawing;
using TagCloud.Extensions;
using TagCloud.Infrastructure;
using TagCloud.Infrastructure.Providers;

namespace TagCloud.Logic.PointGenerators;

public class SpiralPointGenerator : IPointGenerator
{
    private readonly Size _centerPointSize;
    private readonly double _angleStep;
    private readonly double _radiusStep;

    public SpiralPointGenerator(ILogicSettingsProvider logicSettingsProvider)
    {
        var logicSettings = logicSettingsProvider.GetLogicSettings();
        _radiusStep = logicSettings.RadiusStep;
        _angleStep = logicSettings.AngleStep;
        _centerPointSize = logicSettings.Center;
    }

    public IEnumerable<Point> GeneratePoint()
    {
        var radius = 0d;
        var angle = 0d;

        while (true)
        {
            var newX = (int)(radius * Math.Cos(angle));
            var newY = (int)(radius * Math.Sin(angle));
            var newPoint = new Point(newX, newY).MoveTo(_centerPointSize);

            radius += _radiusStep;
            angle += _angleStep;

            yield return newPoint;
        }
        // ReSharper disable once IteratorNeverReturns
    }
}