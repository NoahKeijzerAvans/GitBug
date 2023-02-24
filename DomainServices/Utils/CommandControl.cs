using DomainServices.Context;
using DomainServices.Context.Commands;
using DomainServices.GitCommands;
using DomainServices.GitCommands.Commands;

namespace DomainServices.Utils;

public class CommandControl
{
    public GitCommand Command { get; set; }
    private Project Project { get; }
    public CommandControl(Project project)
    {
        Project = project;
        Command = new NoCommand(project);
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
        
        // ReSharper disable once FunctionNeverReturns
    }

    private void SetCommand(GitCommand command)
    {
        Command = command;
    }
    
    // Invoker
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
                SetCommand(new GitAddChangesCommand(Project));
                CommandWasCalled(new Change(Project));
                break;
            case { } when command.Contains("git commit -m"):
                var description = span[13..];
                SetCommand(new GitCommitCommand(Project));
                CommandWasCalled(description.ToString());
                break;
            case { } when command.Contains("git pull origin"):
                SetCommand(new GitPullCommand(Project));
                CommandWasCalled(null);
                break;
            case { } when command.Contains("git push origin"):
                var branch = span[16..];
                SetCommand(new GitPushCommand(Project));
                CommandWasCalled(branch.ToString());
                break;
            case { } when command.Contains("git checkout -b"):
                var name = span[16..];
                SetCommand(new GitCheckoutCommand(Project));
                CommandWasCalled(name.ToString());
                break;
            case { } when command.Contains("git board"):
                SetCommand(new DrawBoardCommand(Project));
                CommandWasCalled(null);
                break;
            case { } when command.Contains("clear"):
                SetCommand(new GitClearCommand(Project));
                CommandWasCalled(null);
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