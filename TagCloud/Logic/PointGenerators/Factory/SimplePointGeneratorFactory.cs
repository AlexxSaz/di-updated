using TagCloud.Infrastructure;

namespace TagCloud.Logic.PointGenerators.Factory;

public class SimplePointGeneratorFactory : IPointGeneratorFactory
{
    public IPointGenerator CreatePointGenerator(LogicSettings logicSettings) =>
        logicSettings.PointGeneratorType switch
        {
            PointGeneratorType.Astroid => new AstroidPointGenerator(logicSettings),
            PointGeneratorType.Spiral => new SpiralPointGenerator(logicSettings),
            _ => throw new ArgumentOutOfRangeException(nameof(logicSettings.PointGeneratorType),
                logicSettings.PointGeneratorType,
                "No such pointGenerator type.")
        };
}