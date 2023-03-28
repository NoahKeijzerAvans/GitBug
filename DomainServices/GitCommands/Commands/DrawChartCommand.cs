using DomainServices.Context;

namespace DomainServices.GitCommands.Commands
{
    public class DrawChartCommand : GitCommand
    {
        private readonly ScrumBoard _board;
        public DrawChartCommand(Project context) : base(context)
        {
            _board = new ScrumBoard(context.Issues);
        }

        public override void Excecute(dynamic? param)
        {
            _board.DrawChart();
        }
    }
}