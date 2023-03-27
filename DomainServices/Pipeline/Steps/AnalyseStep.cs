using Domain.Models;
using DomainServices.Interfaces.Pipeline;

namespace DomainServices.Pipeline.Steps;

public class AnalyseStep : IPipelineStep
{
    public void Excecute()
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