using Domain.Models;
using DomainServices.Interfaces.Observer;

namespace DomainServices.Pipeline.Steps;

public class UtilityStep : PipelineStep, IObserver
{
    public new void Update(object? arg)
    {
        Console.WriteLine("Excecuting Utility step, please wait.");
        ConsoleSpinner.Draw();
        Console.WriteLine("\nUtility step succeeded!");
    }
    public override string ToString()
    {
        return "Utility";
    }
}

