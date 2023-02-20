using DomainServices.Utils;

namespace DomainServices.GitCommands.Commands;

public class NoCommand : GitCommand
{
    public NoCommand(ChangesTracker tracker) : base(tracker)
    {
    }

    public override void Excecute(dynamic? param)
    {
        Console.WriteLine("No command selected.");
    }
}