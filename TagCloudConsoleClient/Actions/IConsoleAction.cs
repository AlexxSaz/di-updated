using TagCloudConsoleClient.Options;

namespace TagCloudConsoleClient.Actions;

public interface IConsoleAction
{
    SettingsType SettingsType { get; }
    string Perform(IOption iOption);
}