using Domain.Models;
using DomainServices.Interfaces.Pipeline;

namespace DomainServices.Pipeline.Steps;

public class BuildStep : IPipelineStep
{
    public void Excecute()
    {
        Console.WriteLine("Excecuting Build step, please wait.");
        ConsoleSpinner.Draw();
        Console.WriteLine("\nBuild step succeeded!");
    }
    public override string ToString()
    {
        return "Build";
    }
}