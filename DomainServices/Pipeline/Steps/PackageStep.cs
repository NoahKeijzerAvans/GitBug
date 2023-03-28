using Domain.Models;
using DomainServices.Interfaces.Pipeline;

namespace DomainServices.Pipeline.Steps;

public class PackageStep : IPipelineStep
{
    public void Excecute()
    {
        Console.WriteLine("Excecuting Package step, please wait.");
        ConsoleSpinner.Draw();
        Console.WriteLine("\nPackage step succeeded!");
    }
    public override string ToString()
    {
        return "Package";
    }
}