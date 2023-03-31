using DomainServices.Context;

namespace DomainServices.GitCommands.Commands.Board
{
    public class DrawChartCommand : GitCommand
    {
        public DrawChartCommand(Project context) : base(context)
        {
        }

        public override void Excecute(object? param)
        {
            Context.GetCurrentSprint().Scumboard.DrawChart();
        }
    }
}