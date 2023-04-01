using Domain.Models;
using DomainServices.Interfaces.Observer;

namespace DomainServices.Pipeline.Steps;

public class TestStep : PipelineStep, IObserver
{
    public new void Update(object? arg)
    {
        Console.WriteLine("Excecuting Test step, please wait.");
        var random = new Random();
        // int rInt = random.Next(0, 3);
        int rInt = 1;
        if (rInt == 3)
        {
            for (int i = 0; i < 62; i++)
            {
                ConsoleSpinner.WriteProgress(i, true);
                Console.WriteLine("Something went wrong with the tests, please verify and try again later.");
            }
        }
        else
        {
            ConsoleSpinner.Draw();
            Console.WriteLine("\nTests succeeded!");
            IsSucceeded = true;
        }
    }
    public override string ToString()
    {
        return "Test";
    }
}
