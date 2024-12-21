using System.Drawing;
using FluentAssertions;
using TagCloud;
using TagCloud.Extensions;
using TagCloud.Logic.CloudLayouts;
using TagCloud.Logic.PointGenerators;
using TagCloud.Readers;
using TagCloudTests.SizeGenerator;

[assembly: Parallelizable(ParallelScope.Children)]

namespace TagCloudTests;

public class CircularCloudLayoutShould
{
    private readonly Point _defaultCenter = new(0, 0);
    private readonly Random _random = new();
    private readonly ISizesGenerator _defaultSizesGenerator = new RandomSizesGenerator();
    private static readonly IFileReader Reader = new SingleWordInRowFileReader();
    private static readonly AppConfig AppConfig = new(Reader);

    [Test]
    [Repeat(5)]
    public void PutNextRectangle_ReturnRectangleWithExpectedLocation_AfterFirstExecution()
    {
        var expectedCenter = AppConfig.Center;
        var rectangleSize = _defaultSizesGenerator
            .GenerateSize()
            .Take(1)
            .First();
        var pointGenerator = new SpiralPointGenerator(AppConfig);
        var cloudLayout = new CircularCloudLayout(pointGenerator);

        var actualRectangle = cloudLayout.PutNextRectangle(rectangleSize);

        actualRectangle
            .Should()
            .BeEquivalentTo(expectedCenter);
    }

    [TestCase(-1, 1)]
    [TestCase(1, -1)]
    [TestCase(0, 0)]
    public void PutNextRectangle_ThrowArgumentOutOfRangeException_AfterExecutionWith(int width, int height)
    {
        var rectangleSize = new Size(width, height);
        var pointGenerator = new SpiralPointGenerator(AppConfig);
        var circularCloudLayout = new CircularCloudLayout(pointGenerator);

        var executePutNewRectangle = () =>
            circularCloudLayout
                .PutNextRectangle(rectangleSize);

        executePutNewRectangle
            .Should()
            .Throw<ArgumentOutOfRangeException>();
    }

    [Test]
    [Repeat(5)]
    public void PutNextRectangle_ReturnRectangleThatNotIntersectsWithOther_AfterManyExecution()
    {
        var rectangleSizes = _defaultSizesGenerator
            .GenerateSize()
            .Take(_random.Next(10, 200));
        var pointGenerator = new SpiralPointGenerator(AppConfig);
        var cloudLayout = new CircularCloudLayout(pointGenerator);

        var rectangles = rectangleSizes
            .Select(size => cloudLayout.PutNextRectangle(size))
            .ToArray();

        for (var i = 0; i < rectangles.Length; i++)
        for (var j = i + 1; j < rectangles.Length; j++)
            rectangles[i]
                .IntersectsWith(rectangles[j])
                .Should()
                .BeFalse();
    }

    [Test]
    [Repeat(20)]
    public void PutNextRectangle_ReturnRectanglesInCircle_AfterManyExecution()
    {
        var rectangleSizes = _defaultSizesGenerator
            .GenerateSize()
            .Take(_random.Next(100, 200));
        var pointGenerator = new SpiralPointGenerator(AppConfig);
        var circularCloudLayout = new CircularCloudLayout(pointGenerator);

        var rectanglesList = rectangleSizes
            .Select(rectangleSize => circularCloudLayout
                .PutNextRectangle(rectangleSize))
            .ToList();

        var circleRadius = rectanglesList
            .Select(rectangle => rectangle.GetCentralPoint())
            .Max(pointOnCircle => pointOnCircle.GetDistanceTo(_defaultCenter));

        var sumRectanglesSquare = rectanglesList.Sum(rectangle => rectangle.Width * rectangle.Height);
        var circleSquare = circleRadius * circleRadius * Math.PI;
        var precision = circleSquare * 0.375;

        circleSquare
            .Should()
            .BeApproximately(sumRectanglesSquare, precision);
    }
}