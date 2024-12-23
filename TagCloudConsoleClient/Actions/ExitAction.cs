using TagCloudConsoleClient.Options;

namespace TagCloudConsoleClient.Actions;

public class ExitAction : IConsoleAction
{
    public SettingsType SettingsType => SettingsType.Exit;

    public string Perform(IOption option)
    {
        Environment.Exit(0);
        return "Программа завершена.";
    }
}