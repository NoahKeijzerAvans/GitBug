﻿using Domain.Models;
using DomainServices.Interfaces.Pipeline;

namespace DomainServices.Pipeline.Steps;

public class TestStep : IPipelineStep
{
    public void Excecute()
    {
        Console.WriteLine("Excecuting Test step, please wait.");
        var random = new Random();
        int rInt = random.Next(0, 3);
        if (rInt == 3)
        {
            for(int i = 0; i < 62; i++)
            {
                ConsoleSpinner.WriteProgress(i, true);
                Console.WriteLine("Something went wrong with the tests, please verify and try again later.");
            }
        }
        else
        {
            ConsoleSpinner.Draw();
            Console.WriteLine("\nTests succeeded!");
        }
    }
    public override string ToString()
    {
        return "Test";
    }
}