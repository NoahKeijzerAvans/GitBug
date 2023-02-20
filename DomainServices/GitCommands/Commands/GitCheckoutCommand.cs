using DomainServices.Utils;

namespace DomainServices.GitCommands.Commands;

public class GitCheckoutCommand : GitCommand
{
    private ChangesTracker Tracker { get; }

    public GitCheckoutCommand(ChangesTracker tracker) : base(tracker)
    {
        Tracker = tracker;
    }

    public override void Excecute(dynamic? param)
    {
        Tracker.CheckoutBranch(param);
    }
}