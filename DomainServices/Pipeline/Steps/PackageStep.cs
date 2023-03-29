﻿using Domain.Models;
using DomainServices.Observer;

namespace DomainServices.Pipeline.Steps;

public class PackageStep : PipelineStep, IObserver
{
    public new void Update(object? arg)
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