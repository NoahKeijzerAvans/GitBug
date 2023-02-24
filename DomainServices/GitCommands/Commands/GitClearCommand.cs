using DomainServices.Context;

namespace DomainServices.GitCommands.Commands;

public class GitClearCommand: GitCommand
{
    public GitClearCommand(Project context) : base(context)
    {
    }

    public override void Excecute(dynamic? param)
    {
        Console.Clear();
    }
}