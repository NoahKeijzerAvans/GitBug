using DomainServices.Context;
using DomainServices.Utils;

namespace DomainServices.GitCommands.Commands;

public class GitBoardCommand : GitCommand
{
    public GitBoardCommand(Project context) : base(context)
    {
    }

    public override void Excecute(dynamic? param)
    {
        throw new NotImplementedException();
    }
}