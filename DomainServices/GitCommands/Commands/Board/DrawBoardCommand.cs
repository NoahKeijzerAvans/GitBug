using DomainServices.Context;
using DomainServices.Utils;

namespace DomainServices.GitCommands.Commands.Board;

public class DrawBoardCommand : GitCommand
{
    public DrawBoardCommand(Project context) : base(context)
    {
        
    }

    public override void Excecute(object? param)
    {
        Context.GetCurrentSprint().Scumboard.DrawScumBoard();
    }
}