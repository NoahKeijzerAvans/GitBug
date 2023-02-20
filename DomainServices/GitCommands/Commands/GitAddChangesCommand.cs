using DomainServices.Utils;

namespace DomainServices.GitCommands.Commands;

public class GitAddChangesCommand: GitCommand
{
    private ChangesTracker Tracker { get; }
    
    public override void Excecute(dynamic? change)
    {
        Tracker.AddChange(change!);
    }

    public GitAddChangesCommand(ChangesTracker tracker) : base(tracker)
    {
        Tracker = tracker;
    }
}