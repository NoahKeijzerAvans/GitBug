using DomainServices.Context;
using DomainServices.Context.VersionControl;

namespace DomainServices.GitCommands.Commands.VersionControl;

public class GitAddChangesCommand : GitCommand
{
    public GitAddChangesCommand(Project context) : base(context)
    {
    }
    public override void Excecute(object? change)
    {
        Context.AddChange((Change?)change!);
    }
}