using System.Drawing;
using FluentAssertions;
using TagCloud.Extensions;
using TagCloud.Infrastructure.Providers;
using TagCloud.Logic.CloudLayouts;
using TagCloud.Logic.PointGenerators.Factory;
using TagCloudTests.SizeGenerator;

[assembly: Parallelizable(ParallelScope.Children)]

namespace TagCloudTests;

public class SimpleCloudLayoutShould
{
    private readonly Point _defaultCenter = new();
    private readonly Random _random = new();
    private readonly ISizesGenerator _defaultSizesGenerator = new RandomSizesGenerator();
    private readonly LogicSettingsProvider _logicSettingsProvider = new();
    private readonly SimplePointGeneratorFactory _simplePointGeneratorFactory = new();

    [Test]
    [Repeat(5)]
    public void PutNextRectangle_ReturnRectangleWithExpectedLocation_AfterFirstExecution()
    {
        var expectedCenter = new Point(_random.Next(-10, 10), _random.Next(-10, 10));
        _logicSettingsProvider.SetCenterSize(new Size(expectedCenter));
        var logicSettings = _logicSettingsProvider.GetLogicSettings();
        var rectangleSize = _defaultSizesGenerator
            .GenerateSize()
            .Take(1)
            .First();
        var cloudLayout = new SimpleCloudLayout(logicSettings, _simplePointGeneratorFactory);

        var actualRectangle = cloudLayout.PutNextRectangle(rectangleSize);

        actualRectangle
            .GetCentralPoint()
            .Should()
            .BeEquivalentTo(expectedCenter);
    }

    [TestCase(-1, 1)]
    [TestCase(1, -1)]
    [TestCase(0, 0)]
    public void PutNextRectangle_ThrowArgumentOutOfRangeException_AfterExecutionWith(int width, int height)
    {
        var logicSettings = _logicSettingsProvider.GetLogicSettings();
        var rectangleSize = new Size(width, height);
        var circularCloudLayout = new SimpleCloudLayout(logicSettings, _simplePointGeneratorFactory);

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
        var logicSettings = _logicSettingsProvider.GetLogicSettings();
        var rectangleSizes = _defaultSizesGenerator
            .GenerateSize()
            .Take(_random.Next(10, 200));
        var cloudLayout = new SimpleCloudLayout(logicSettings, _simplePointGeneratorFactory);

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
        var logicSettings = _logicSettingsProvider.GetLogicSettings();
        var rectangleSizes = _defaultSizesGenerator
            .GenerateSize()
            .Take(_random.Next(100, 200));
        var circularCloudLayout = new SimpleCloudLayout(logicSettings, _simplePointGeneratorFactory);

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