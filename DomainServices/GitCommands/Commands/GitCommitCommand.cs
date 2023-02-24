using DomainServices.Context;

namespace DomainServices.GitCommands.Commands;

public class GitCommitCommand : GitCommand
{

    public GitCommitCommand(Project context) : base(context)
    {
    }

    public override void Excecute(dynamic? param)
    {
        Context.CommitChanges(param!);
    }
}