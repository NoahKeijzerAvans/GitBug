using DomainServices.Context.Commands;
using DomainServices.GitCommands;
using DomainServices.GitCommands.Commands;

namespace DomainServices.Utils;

public class CommandControl
{
    public GitCommand Command { get; set; }
    private ChangesTracker Tracker { get; }
    public CommandControl(ChangesTracker tracker)
    {
        Tracker = tracker;
        Command = new NoCommand(Tracker);
    }

    public void Listen()
    {
        Console.WriteLine("Welcome to GitBug, your command is my order!");
        while (true)
        {
            var command = Console.ReadLine();
            try
            {
                ChooseCommand(command!);
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid operation.");
            }
        }
    }

    private void SetCommand(GitCommand command)
    {
        Command = command;
    }

    private void CommandWasCalled(dynamic? paramether)
    {
        Command.Excecute(paramether);
    }

    public void ChooseCommand(string command)
    {
        ReadOnlySpan<char> span = command;
        switch (command)
        {
            case { } when command.Contains("git add"):
                SetCommand(new GitAddChangesCommand(Tracker));
                CommandWasCalled(new Change());
                break;
            case { } when command.Contains("git commit -m"):
                var description = span[13..];
                SetCommand(new GitCommitCommand(Tracker));
                CommandWasCalled(description.ToString());
                break;
            case { } when command.Contains("git pull origin"):
                SetCommand(new GitPullCommand(Tracker));
                CommandWasCalled(null);
                break;
            case { } when command.Contains("git push origin"):
                var branch = span[16..];
                SetCommand(new GitPushCommand(Tracker));
                CommandWasCalled(branch.ToString());
                break;
            case { } when command.Contains("git checkout -b"):
                var name = span[16..];
                SetCommand(new GitCheckoutCommand(Tracker));
                CommandWasCalled(name.ToString());
                break;
            default:
                Console.WriteLine("Valid operations: ");
                Console.WriteLine("git commit -m");
                Console.WriteLine("git add");
                Console.WriteLine("git pull origin");
                Console.WriteLine("git checkout -b");
                break;
        }
    }
}