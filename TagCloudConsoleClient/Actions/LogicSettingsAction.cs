using TagCloud.Infrastructure.Providers.Interfaces;
using TagCloud.Logic.PointGenerators;
using TagCloudConsoleClient.Options;

namespace TagCloudConsoleClient.Actions;

public class LogicSettingsAction(ILogicSettingsProvider logicSettingsProvider) : IConsoleAction
{
    public SettingsType SettingsType => SettingsType.Logic;

    public string Perform(IOption option)
    {
        var optionSettings = (LogicSettingsOption)option;
        var pointGeneratorType = GetPointGeneratorType(optionSettings.PointGeneratorType);
        logicSettingsProvider.SetAngleStep(optionSettings.AngleStep);
        logicSettingsProvider.SetRadiusStep(optionSettings.RadiusStep);
        logicSettingsProvider.SetPointGenerator(pointGeneratorType);
        return $"Настройки логики изменены.\n" +
               $"Шаг угола {optionSettings.AngleStep}, шаг радиуса {optionSettings.RadiusStep}.\n" +
               $"Форма генерации точек: {pointGeneratorType}.";
    }

    private static PointGeneratorType GetPointGeneratorType(int optionSettingsPointGeneratorType) =>
        optionSettingsPointGeneratorType switch
        {
            1 => PointGeneratorType.Spiral,
            2 => PointGeneratorType.Astroid,
            _ => PointGeneratorType.Spiral
        };
}