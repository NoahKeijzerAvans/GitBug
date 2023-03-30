using DomainServices.Context;

namespace DomainServices.GitCommands.Commands.VersionControl;

public class GitPullCommand : GitCommand
{
    public GitPullCommand(Project context) : base(context)
    {
    }

    public override void Excecute(object? param)
    {
        Context.PullToWorkingDirectory();
    }
}