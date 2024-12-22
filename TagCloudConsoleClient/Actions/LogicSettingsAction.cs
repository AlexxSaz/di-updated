using TagCloud.Infrastructure;
using TagCloud.Infrastructure.Providers;
using TagCloudConsoleClient.Options;

namespace TagCloudConsoleClient.Actions;

public class LogicSettingsAction(ILogicSettingsProvider logicSettingsProvider) : IConsoleAction
{
    public SettingsType SettingsType => SettingsType.Logic;

    public string Perform(IOption option)
    {
        var optionSettings = (LogicSettingsOption)option;
        logicSettingsProvider.SetAngleStep(optionSettings.AngleStep);
        logicSettingsProvider.SetRadiusStep(optionSettings.RadiusStep);
        logicSettingsProvider.SetCloudLayout(optionSettings.CloudLayout);
        return $"Настройки логики изменены. " +
               $"Шаг угола {optionSettings.AngleStep}, шаг радиуса {optionSettings.RadiusStep}.";
    }
}