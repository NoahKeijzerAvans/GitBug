using DomainServices.Context;

namespace DomainServices.GitCommands.Commands.Thread;

public class ShowThreadsCommand : GitCommand
{
    public ShowThreadsCommand(Project context) : base(context)
    {
    }

    public override void Excecute(object? param)
    {
        Context.GetCurrentSprint().ShowThreads();
    }
}
