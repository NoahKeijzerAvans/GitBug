using DomainServices.Context;
using DomainServices.Context.VersionControl;
using DomainServices.Utils;

namespace DomainServices.GitCommands.Commands;

public class GitAddChangesCommand : GitCommand
{
    public GitAddChangesCommand(Project context) : base(context)
    {
    }
    public override void Excecute(dynamic? change)
    {
        Context.AddChange((Change?)change);
    }
}