using Domain.Enums;
using Domain.Models;
using DomainServices.Context;
using DomainServices.Context.Task;

namespace DomainServices.GitCommands.Commands.ScrumTasks;

public class GitAddTaskCommand : GitCommand
{
    private int CursorTop { get; set; }
    private List<KeyValuePair<Person, bool>>? OptionsPeople { get; set; }
    private List<KeyValuePair<Type, bool>> OptionsTasks { get; set; }
    private List<KeyValuePair<Priority, bool>> OptionsPriority { get; set; }
    private bool EnterPressed { get; set; }
    public GitAddTaskCommand(Project context) : base(context)
    {
        OptionsPeople = new List<KeyValuePair<Person, bool>>();
        OptionsTasks = new List<KeyValuePair<Type, bool>>
        {
            new (typeof(Bug), true),
            new (typeof(Change), false),
            new (typeof(Epic), false),
            new (typeof(Incident), false),
            new (typeof(Problem), false),
            new (typeof(Story), false)
        };

        foreach (var contributor in Context.Contributors)
        {
            OptionsPeople?.Add(!OptionsPeople!.Any()
                ? new KeyValuePair<Person, bool>(contributor, true)
                : new KeyValuePair<Person, bool>(contributor, false));
        }

        OptionsPriority = new List<KeyValuePair<Priority, bool>>
        {
            new(Priority.High, true),
            new(Priority.Moderate, false),
            new(Priority.Low, false)
        };

    }

    public override void Excecute(dynamic? param)
    {
        Console.WriteLine();
        Console.WriteLine("Select the type of task that needs to be created by pressing Enter key.");
        SelectTypeTask();
    }

    private Person SelectPerson()
    {
        EnterPressed = false;
        while (!EnterPressed)
        {
            foreach (var option in OptionsPeople!)
            {
                Console.WriteLine(option.Value ? $"[x] {option.Key.FullName} " : $"[] {option.Key.FullName} ");
            }
            CursorTop = +Console.CursorTop - OptionsPeople.Count;
            OptionsPeople = ReadKeyPressed(CursorTop, OptionsPeople);
        }

        CursorTop = +Console.CursorTop + OptionsPeople!.Count;
        Console.SetCursorPosition(0, CursorTop);
        return OptionsPeople!.FirstOrDefault(p => p.Value).Key;
    }

    private Priority SelectPriority()
    {
        EnterPressed = false;
        while (!EnterPressed)
        {
            foreach (var option in OptionsPriority)
            {
                Console.WriteLine(option.Value ? $"[x] {option.Key} " : $"[] {option.Key} ");
            }
            CursorTop = +Console.CursorTop - OptionsPriority.Count;
            OptionsPriority = ReadKeyPressed(CursorTop, OptionsPriority);
        }

        CursorTop = +Console.CursorTop + OptionsPriority.Count;
        Console.SetCursorPosition(0, CursorTop);
        return OptionsPriority.FirstOrDefault(p => p.Value).Key;
    }
    private void SelectTypeTask()
    {
        EnterPressed = false;
        while (!EnterPressed)
        {
            foreach (var option in OptionsTasks)
            {
                Console.WriteLine(option.Value ? $"[x] {option.Key.Name} " : $"[] {option.Key.Name} ");
            }

            CursorTop = +Console.CursorTop - OptionsTasks.Count;
            OptionsTasks = ReadKeyPressed(CursorTop, OptionsTasks);
        }
        CursorTop = +Console.CursorTop + OptionsTasks.Count;
        Console.SetCursorPosition(0, CursorTop);
    }

    private void CreateIssue()
    {
        Console.SetCursorPosition(0, CursorTop + 7);
        var type = OptionsTasks.FirstOrDefault(o => o.Value);
        var addIssue = type.Key;
        var issueToBeAdded = SelectInstance(addIssue);

        Console.Write("Enter the name of the issue: ");
        issueToBeAdded!.Name = Console.ReadLine()!;
        Console.Write("Enter the description of the issue: ");
        issueToBeAdded.Description = Console.ReadLine()!;
        Console.WriteLine("Select the priority of the issue: ");
        issueToBeAdded.Priority = SelectPriority();
        Console.Write("Enter the amount of story points assigned to the issue: ");
        issueToBeAdded.StoryPoints = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Enter the name person assigned to the issue: ");
        issueToBeAdded.AssignedTo = SelectPerson();
        Context.Issues.Add(issueToBeAdded);
        Console.WriteLine("Issue added successfully!");
        Console.WriteLine();
    }

    private Issue? SelectInstance(Type type)
    {
        if (type == typeof(Bug))
        {
            var bug = (Bug)Activator.CreateInstance(type)!;
            return EnterExtraInformationForBug(bug);
        }
        if (type == typeof(Change))
        {
            var change = (Change)Activator.CreateInstance(type)!;
            return EnterExtraInformationForChange(change);
        }

        if (type == typeof(Epic))
        {
            var epic = (Epic)Activator.CreateInstance(type)!;
            return EnterExtraInformationForEpic(epic);
        }
        if (type == typeof(Incident))
        {
            var incident = (Incident)Activator.CreateInstance(type)!;
            return EnterExtraInformationForIncident(incident);
        }

        if (type == typeof(Problem))
        {
            var problem = (Problem)Activator.CreateInstance(type)!;
            return EnterExtraInformationForProblem(problem);
        }
        if (type == typeof(Story))
        {
            var story = (Story)Activator.CreateInstance(type)!;
            return EnterExtraInformationForStory(story);
        }
        return null;
    }

    private Issue EnterExtraInformationForStory(Story story)
    {
        Console.Write("Provide a narrative of the story");
        story.Narrative = Console.ReadLine();
        Console.Write("Provide the acceptance criteria of the story");
        story.AcceptanceCriteria = Console.ReadLine();
        return story;
    }

    private Issue EnterExtraInformationForProblem(Problem problem)
    {
        Console.Write("Provide a summary of the problem: ");
        problem.Summary = Console.ReadLine()!;
        Console.Write("Provide a request type of the problem: ");
        problem.RequestType = Console.ReadLine()!;
        return problem;
    }

    private Issue EnterExtraInformationForIncident(Incident incident)
    {
        Console.Write("Provide a summary of the incident: ");
        incident.Summary = Console.ReadLine();
        Console.Write("Provide the affected business service of the incident: ");
        incident.AffectedBusinessService = Console.ReadLine();
        Console.Write("Provide the affected business server of the incident: ");
        incident.AffectedServer = Console.ReadLine();
        Console.WriteLine("Select the reporter of the incident: ");
        incident.Reporter = SelectPerson();
        return incident;
    }

    private Issue EnterExtraInformationForChange(Change change)
    {
        Console.Write("Provide a summary of the change: ");
        change.Summary = Console.ReadLine();
        Console.Write("Provide a request type of the change: ");
        change.RequestType = Console.ReadLine();
        return change;
    }

    private Issue EnterExtraInformationForBug(Bug bug)
    {
        Console.Write("Provide a summary of the bug: ");
        bug.Summary = Console.ReadLine()!;
        Console.WriteLine("Provide the name of the person who requested: ");
        bug.RequestedBy = SelectPerson();
        return bug;
    }

    private Issue EnterExtraInformationForEpic(Epic epic)
    {
        Console.WriteLine("Provide a summary of the epic: ");
        epic.Summary = Console.Read().ToString();
        return epic;
    }
    private List<KeyValuePair<T, bool>> ReadKeyPressed<T>(int cursorTop, List<KeyValuePair<T, bool>> optionsList)
    {
        var key = Console.ReadKey();

        var optionSelected = optionsList.FirstOrDefault(o => o.Value);
        var indexSelected = optionsList.IndexOf(optionSelected);
        Console.SetCursorPosition(0, cursorTop);

        switch (key.Key)
        {
            case ConsoleKey.DownArrow:
                if (indexSelected + 1 >= optionsList.Count)
                {
                    optionsList[indexSelected] = new KeyValuePair<T, bool>(optionSelected.Key, false);
                    indexSelected = 0;
                    optionsList[indexSelected] = new KeyValuePair<T, bool>(optionsList[indexSelected].Key, true);
                }
                else
                {
                    optionsList[indexSelected] = new KeyValuePair<T, bool>(optionSelected.Key, false);
                    optionsList[indexSelected + 1] = new KeyValuePair<T, bool>(optionsList[indexSelected + 1].Key, true);
                }
                EnterPressed = false;
                break;
            case ConsoleKey.UpArrow:
                {
                    if (indexSelected - 1 < 0)
                    {
                        optionsList[indexSelected] = new KeyValuePair<T, bool>(optionSelected.Key, false);
                        indexSelected = optionsList.Count - 1;
                        optionsList[indexSelected] = new KeyValuePair<T, bool>(optionsList[indexSelected].Key, true);
                    }
                    else
                    {
                        optionsList[indexSelected] = new KeyValuePair<T, bool>(optionSelected.Key, false);
                        optionsList[indexSelected - 1] = new KeyValuePair<T, bool>(optionsList[indexSelected - 1].Key, true);
                    }
                    EnterPressed = false;
                    break;
                }
            case ConsoleKey.Enter:
                EnterPressed = true;
                if (typeof(T) == typeof(Person) || typeof(T) == typeof(Priority))
                    break;
                if (typeof(T) == typeof(Type))
                    CreateIssue();
                break;
            default:
                EnterPressed = false;
                break;
        }
        return optionsList;
    }
}