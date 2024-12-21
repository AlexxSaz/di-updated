using System.Drawing;
using TagCloud.Extensions;
using TagCloud.Logic.PointGenerators;

namespace TagCloud.Logic.CloudLayouts;

public class CircularCloudLayout(IPointGenerator pointGenerator) : ICloudLayout
{
    private readonly IEnumerator<Point> _pointGeneratorIterator = pointGenerator
        .GeneratePoint()
        .GetEnumerator();

    private readonly List<Rectangle> _rectangles = [];

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