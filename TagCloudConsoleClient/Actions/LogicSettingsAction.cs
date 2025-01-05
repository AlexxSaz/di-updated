using TagCloud.Infrastructure;
using TagCloud.Infrastructure.Providers.Interfaces;
using TagCloud.Logic.PointGenerators;
using TagCloudConsoleClient.Options;

namespace TagCloudConsoleClient.Actions;

public class LogicSettingsAction(ILogicSettingsProvider logicSettingsProvider) : IConsoleAction
{
    public OptionType OptionType => OptionType.Logic;

    public string Perform(IOption option)
    {
        var optionSettings = (LogicSettingsOption)option;
        logicSettingsProvider.SetLogicSettings(CreateImageSetting(optionSettings));
        return $"Настройки логики изменены.\n" +
               $"Шаг угола {optionSettings.AngleStep}, шаг радиуса {optionSettings.RadiusStep}.\n" +
               $"Форма генерации точек: {GetPointGeneratorType(optionSettings.PointGeneratorType)}.\n";
    }
    
    private static LogicSettings CreateImageSetting(LogicSettingsOption logicSettingsOption)
    {
        var logicSettings = new LogicSettings();

        return logicSettings with
        {
            AngleStep = logicSettingsOption.AngleStep,
            RadiusStep = logicSettingsOption.RadiusStep,
            PointGeneratorType = GetPointGeneratorType(logicSettingsOption.PointGeneratorType)
        };
    }

    private static PointGeneratorType GetPointGeneratorType(int optionSettingsPointGeneratorType) =>
        optionSettingsPointGeneratorType switch
        {
            1 => PointGeneratorType.Spiral,
            2 => PointGeneratorType.Astroid,
            _ => PointGeneratorType.Spiral
        };
}