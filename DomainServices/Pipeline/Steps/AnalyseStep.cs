using Domain.Models;
using DomainServices.Interfaces.Observer;

namespace DomainServices.Pipeline.Steps;

public class AnalyseStep : PipelineStep, IObserver
{
    public new void Update(object? data)
    {
        Console.WriteLine("Excecuting Analyse step, please wait.");
        ConsoleSpinner.Draw();
        Console.WriteLine("\nAnalyse step succeeded!");
        IsSucceeded = true;
    }
    public override string ToString()
    {
        return "Analyse";
    }
}