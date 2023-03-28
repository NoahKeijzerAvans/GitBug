using DomainServices.Context;
using DomainServices.Utils;

namespace DomainServices.GitCommands.Commands.ScrumBoard;

public class DrawBoardCommand : GitCommand
{
    private readonly ScrumBoard _board;
    public DrawBoardCommand(Project context) : base(context)
    {
        _board = new ScrumBoard(context.Issues);
    }

    public override void Excecute(dynamic? param)
    {
        _board.DrawScumBoard();
    }
}