using DomainServices.Utils;

namespace DomainServices.GitCommands.Commands;

public class GitBoardCommand: GitCommand
{
    public GitBoardCommand(ChangesTracker tracker) : base(tracker)
    {
    }

    public override void Excecute(dynamic? param)
    {
        throw new NotImplementedException();
    }
}