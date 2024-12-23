using System.Drawing;
using TagCloud.Calculators;
using TagCloud.Extensions;
using TagCloud.Infrastructure;
using TagCloud.Infrastructure.Providers.Interfaces;
using TagCloud.Infrastructure.Tags;
using TagCloud.Logic.PointGenerators;
using TagCloud.WordHandlers;

namespace TagCloud.Logic.CloudLayouts;

public class CircularCloudLayout : ICloudLayout
{
    private readonly IEnumerator<Point> _pointGeneratorIterator;

    private readonly List<Rectangle> _rectangles = [];

    public CircularCloudLayout(LogicSettings logicSettings)
    {
        var pointGenerator = new SpiralPointGenerator(logicSettings);

        _pointGeneratorIterator = pointGenerator
            .GeneratePoint()
            .GetEnumerator();
    }
    
    public List<IWordTag> GetTags(IEnumerable<string> words, IWordHandler wordHandler, ISizeCalculator sizeCalculator)
    {
        var handledWords = wordHandler.Handle(words);
        return sizeCalculator.Calculate(handledWords);
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