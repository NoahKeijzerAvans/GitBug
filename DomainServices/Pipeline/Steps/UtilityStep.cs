using Domain.Models;
using DomainServices.Interfaces.Pipeline;

namespace DomainServices.Pipeline.Steps;

public class UtilityStep : IPipelineStep
{
    public void Excecute()
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

