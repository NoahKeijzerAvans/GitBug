using Domain.Models;
using DomainServices.Interfaces.Observer;

namespace DomainServices.Pipeline.Steps;

public class DeployStep : PipelineStep, IObserver
{
    public new void Update(object? arg)
    {
        Console.WriteLine("Excecuting Deploy step, please wait.");
        ConsoleSpinner.Draw();
        Console.WriteLine("\nDeployment step succeeded!");
        IsSucceeded = true;
    }
    public override string ToString()
    {
        return "Deploy";
    }
}