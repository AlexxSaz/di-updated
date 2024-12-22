using CommandLine;
using TagCloudConsoleClient.Actions;
using TagCloudConsoleClient.Options;

namespace TagCloudConsoleClient.Runners;

public class SimpleAppRunner : IAppRunner
{
    private readonly IReadOnlyDictionary<SettingsType, IConsoleAction> _routeActions;

    public SimpleAppRunner(IEnumerable<IConsoleAction> actions)
    {
        var actionsArray = actions.ToArray();
        _routeActions = actionsArray.ToDictionary(action => action.SettingsType, action => action);
    }
    
    private readonly Type[] _optionsTypes =
    [
        typeof(ImageSettingsOption),
        typeof(LogicSettingsOption),
        typeof(SaveImageOption)
    ];

    public void Run()
    {
        while (true)
        {
            var input = Console.ReadLine();
            var args = input?.Split(' ', StringSplitOptions.RemoveEmptyEntries) ?? [];
            Parser.Default.ParseArguments(args, _optionsTypes)
                .WithParsed<IOption>(Perform);
        }
        // ReSharper disable once FunctionNeverReturns
    }
    
    private void Perform(IOption option)
    {
        var action = _routeActions[option.SettingsType];
        Console.WriteLine(action.Perform(option));
    }
}