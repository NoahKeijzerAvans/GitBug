using DomainServices.Utils;

namespace DomainServices.GitCommands.Commands;

public class GitCommitCommand : GitCommand
{
    private ChangesTracker Tracker { get; }

    public GitCommitCommand(ChangesTracker tracker) : base(tracker)
    {
        Tracker = tracker;
    }

    public override void Excecute(dynamic? param)
    {
        Tracker.CommitChanges(param!);
    }
}