using DomainServices.Context;

namespace DomainServices.GitCommands.Commands;

public class NoCommand : GitCommand
{
    public NoCommand(Project context) : base(context)
    {
    }
    public override void Excecute(object? param)
    {
        Console.WriteLine("No command selected.");
    }
}