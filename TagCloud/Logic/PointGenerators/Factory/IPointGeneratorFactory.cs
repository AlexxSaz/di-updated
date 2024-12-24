using TagCloud.Infrastructure;

namespace TagCloud.Logic.PointGenerators.Factory;

public interface IPointGeneratorFactory
{
    IPointGenerator CreatePointGenerator(LogicSettings logicSettings);
}