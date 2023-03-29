using Domain.Models;
using DomainServices.Observer;

namespace DomainServices.Pipeline.Steps;

public class AnalyseStep : PipelineStep, IObserver
{
    public new void Update(object? data)
    {
        Console.WriteLine("Excecuting Analyse step, please wait.");
        ConsoleSpinner.Draw();
        Console.WriteLine("\nAnalyse step succeeded!");
    }
    public override string ToString()
    {
        return "Analyse";
    }
}