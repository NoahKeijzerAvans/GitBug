using Domain.Models;
using DomainServices.Interfaces.Observer;

namespace DomainServices.Pipeline.Steps;

public class BuildStep : PipelineStep, IObserver
{ 
    public new void Update(object? data)
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