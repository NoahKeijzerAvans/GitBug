using DomainServices.Context;
using DomainServices.Context.VersionControl;
using DomainServices.GitCommands;
using DomainServices.GitCommands.Commands;
using DomainServices.GitCommands.Commands.Board;
using DomainServices.GitCommands.Commands.ScrumTasks;
using DomainServices.GitCommands.Commands.Thread;
using DomainServices.GitCommands.Commands.VersionControl;

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
        Console.Clear();
        Console.WriteLine("Welcome to GitBug, your command is my order!");
        while (true)
        {
            var command = Console.ReadLine();
            try
            {
                ChooseCommand(command!);
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid operation:" + e.Message);
            }
        }
    }

    private void SetCommand(GitCommand command)
    {
        Command = command;
    }
    
    // Invoker
    private void CommandWasCalled(object? paramether)
    {
        Command.Excecute(paramether);
    }

    public void ChooseCommand(string command)
    {
        ReadOnlySpan<char> span = command;
        switch (command)
        {
            case { } when command.Contains("git state"):
                SetCommand(new GitState(Project));
                CommandWasCalled(null);
                break;
            case { } when command.Contains("git add"):
                SetCommand(new GitAddChangesCommand(Project));
                CommandWasCalled(new Change(Project));
                break;
            case { } when command.Contains("git commit"):
                var message = span[16..];
                SetCommand(new GitCommitCommand(Project));
                CommandWasCalled(message.ToString());
                break;
            case { } when command.Contains("git pull"):
                SetCommand(new GitPullCommand(Project));
                CommandWasCalled(null);
                break;
            case { } when command.Contains("git push"):
                SetCommand(new GitPushCommand(Project));
                CommandWasCalled(null);
                break;
            case { } when command.Contains("git checkout"):
                var name = span[16..];
                SetCommand(new GitCheckoutCommand(Project));
                CommandWasCalled(name.ToString());
                break;
            case { } when command.Contains("git board"):
                SetCommand(new DrawBoardCommand(Project));
                CommandWasCalled(null);
                break;
            case { } when command.Contains("git chart"):
                SetCommand(new DrawChartCommand(Project));
                CommandWasCalled(null);
                break;
            case { } when command.Contains("git threads"):
                SetCommand(new ShowThreadsCommand(Project));
                CommandWasCalled(null);
                break;
            case { } when command.Contains("clear"):
                SetCommand(new GitClearCommand(Project));
                CommandWasCalled(null);
                break;
            case { } when command.Contains("git task"):
                SetCommand(new GitAddTaskCommand(Project));
                CommandWasCalled(null);
                break;
            case { } when command.Contains("git clone"):
                SetCommand(new GitCloneCommand(null!));
                CommandWasCalled(null);
                break;
            default:
                Console.WriteLine();
                Console.WriteLine("Valid operations: ");
                Console.WriteLine("git commit");
                Console.WriteLine("git add");
                Console.WriteLine("git pull");
                Console.WriteLine("git checkout");
                Console.WriteLine("git clone");
                Console.WriteLine("git task");
                Console.WriteLine("git threads");
                Console.WriteLine("git board");
                Console.WriteLine("clear");
                Console.WriteLine();
                break;
        }
    }
}