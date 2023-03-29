using Domain.Models;
using DomainServices.Interfaces.Pipeline;

namespace DomainServices.Pipeline.Steps;

public class DeployStep : IPipelineStep
{
    public void Excecute()
    {
        Console.WriteLine("Excecuting Deploy step, please wait.");
        ConsoleSpinner.Draw();
        Console.WriteLine("\nDeployment step succeeded!");
    }
    public override string ToString()
    {
        return "Deploy";
    }
}