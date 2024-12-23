using System.Drawing;
using FluentAssertions;
using TagCloud.Extensions;
using TagCloud.Infrastructure;
using TagCloud.Logic.PointGenerators;

namespace TagCloudTests;

public class SpiralPointGeneratorShould
{
    private static readonly LogicSettings LogicSettings = new();
    private readonly Point _defaultCenter = new();
    private readonly Random _random = new();

    [Test]
    public void GetNewPoint_ReturnCenter_AfterFirstExecution()
    {
        var pointGenerator = new SpiralPointGenerator(LogicSettings);
        using var newPointIterator = pointGenerator
            .GeneratePoint()
            .GetEnumerator();
        newPointIterator.MoveNext();
        var point = newPointIterator.Current;

        point
            .Should()
            .BeEquivalentTo(_defaultCenter);
    }

    [Test]
    [Repeat(20)]
    public void GetNewPoint_ReturnPointWithGreaterRadius_AfterManyExecutions()
    {
        var newPointGenerator = new SpiralPointGenerator(LogicSettings);
        var countOfPoints = _random.Next(10, 200);
        var points = newPointGenerator
            .GeneratePoint()
            .Take(countOfPoints)
            .ToArray();

        var distances = points
            .Select(p => p.GetDistanceTo(_defaultCenter))
            .ToArray();
        var angles = points
            .Select(p => Math.Atan2(p.Y - _defaultCenter.Y, p.X - _defaultCenter.X))
            .ToArray();

        distances
            .Zip(distances.Skip(1), (a, b) => a <= b)
            .All(x => x)
            .Should()
            .BeTrue();
        angles
            .Zip(angles.Skip(1), (a, b) => a <= b || Math.Abs(a - b) < 0.1)
            .All(x => x)
            .Should()
            .BeTrue();
    }
}