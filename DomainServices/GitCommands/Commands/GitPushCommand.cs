using DomainServices.Utils;

namespace DomainServices.GitCommands.Commands;

public class GitPushCommand : GitCommand
{
    private ChangesTracker Tracker { get; }
    public GitPushCommand(ChangesTracker tracker) : base(tracker)
    {
        Tracker = tracker;
    }

    public override void Excecute(dynamic? param)
    {
        Tracker.PushToRemote();
    }
}