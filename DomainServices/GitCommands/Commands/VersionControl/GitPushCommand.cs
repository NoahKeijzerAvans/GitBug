using DomainServices.Context;

namespace DomainServices.GitCommands.Commands.VersionControl;

public class GitPushCommand : GitCommand
{
    public GitPushCommand(Project context) : base(context)
    {
    }

    public override void Excecute(object? param)
    {
        Context.PushToRemote();
    }
}