using DomainServices.Utils;

namespace DomainServices.GitCommands.Commands;

public class GitPullCommand: GitCommand
{
    private ChangesTracker Tracker { get; }
    
    public GitPullCommand(ChangesTracker tracker) : base(tracker)
    {
        Tracker = tracker;
    }

    public override void Excecute(dynamic? param)
    {
        Tracker.PullToWorkingDirectory();
    }
}