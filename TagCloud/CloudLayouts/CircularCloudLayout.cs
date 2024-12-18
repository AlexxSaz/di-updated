using System.Drawing;
using TagCloud.Extensions;
using TagCloud.PointGenerators;

namespace TagCloud.CloudLayouts;

public class CircularCloudLayout : ICloudLayout
{
    private readonly IEnumerator<Point> _pointGeneratorIterator;
    private readonly List<Rectangle> _rectangles = [];

    public CircularCloudLayout(Point center, IPointGenerator pointGenerator)
    {
        _pointGeneratorIterator = pointGenerator
            .GeneratePoint()
            .GetEnumerator();
    }

    public Rectangle PutNextRectangle(Size size)
    {
        if (size.Width < 1 || size.Height < 1)
            throw new ArgumentOutOfRangeException(
                $"{nameof(size.Width)} and {nameof(size.Height)} should be greater than zero");

        Rectangle newRectangle;
        do newRectangle = GetNextRectangle(size);
        while (_rectangles.Any(rec => rec.IntersectsWith(newRectangle)));

        _rectangles.Add(newRectangle);
        return newRectangle;
    }

    private Rectangle GetNextRectangle(Size rectangleSize) =>
        new(GetNextRectangleCenter(rectangleSize), rectangleSize);

    private Point GetNextRectangleCenter(Size rectangleSize)
    {
        _pointGeneratorIterator.MoveNext();
        var rectangleCenter = ShiftRectangleLocationBy(rectangleSize);
        return _pointGeneratorIterator
            .Current
            .MoveTo(rectangleCenter);
    }

    private static Size ShiftRectangleLocationBy(Size rectangleSize) =>
        new(-rectangleSize.Width / 2, rectangleSize.Height / 2);
}