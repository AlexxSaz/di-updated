using TagCloud.Infrastructure;
using TagCloud.Infrastructure.Providers.Interfaces;
using TagCloudConsoleClient.Options;

namespace TagCloudConsoleClient.Actions;

public class LogicSettingsAction(ILogicSettingsProvider logicSettingsProvider, LogicSettings logicSettings)
    : IConsoleAction
{
    public OptionType OptionType => OptionType.Logic;

    public string Perform(IOption option)
    {
        var optionSettings = (LogicSettingsOption)option;
        var currentLogicSettings = CreateImageSetting(optionSettings);
        logicSettingsProvider.SetLogicSettings(currentLogicSettings);
        return $"Настройки логики изменены.\n" +
               $"Шаг угола {optionSettings.AngleStep}, шаг радиуса {optionSettings.RadiusStep}.\n" +
               $"Форма генерации точек: {optionSettings.PointGeneratorType}.\n";
    }

    private LogicSettings CreateImageSetting(LogicSettingsOption logicSettingsOption) =>
        logicSettings with
        {
            AngleStep = logicSettingsOption.AngleStep,
            RadiusStep = logicSettingsOption.RadiusStep,
            PointGeneratorType = logicSettingsOption.PointGeneratorType
        };
}