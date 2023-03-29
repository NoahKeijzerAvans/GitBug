using ConsoleTables;
using DomainServices.Context.Task;
using DomainServices.States.IssuesState;

namespace DomainServices.Context;

public class ScrumBoard
{
    private CompositeIssue Issues { get; }

    public ScrumBoard(CompositeIssue issues)
    {
        Issues = issues;
    }

    public void DrawScumBoard()
    {
        Console.WriteLine();
        Console.WriteLine($"{Issues.Name}");
        Console.WriteLine($"{Issues.Description}");
        Issues.Issues.ForEach(i => { i.State ??= new ToDoState(i); });
        Console.WriteLine();
        Console.WriteLine($"Total Story Points: {Issues.TotalStoryPoints}");
        Console.WriteLine($"Total Completed Story Points: {Issues.TotalCompletedStoryPoints}");
        Console.WriteLine();
        var table = new ConsoleTable("To Do", "In Progress", "Ready to Test","Tested", "Done", "Canceled");
        foreach (var issue in Issues.Issues)
        {
            switch (issue.State)
            {
                case ToDoState:
                    AddRowTodo(table, issue);
                    break;
                case InProgressState:
                    AddRowInProgress(table, issue);
                    break;
                case ReadyToTestState:
                    AddRowToReadyToTest(table, issue);
                    break;
                case TestedState:
                    AddRowToTested(table, issue);
                    break;
                case DoneState:
                    AddRowDone(table, issue);
                    break;
                case CanceledState:
                    AddRowCanceled(table, issue);
                    break;
            }
        }
        table.Write();
        Console.WriteLine();
    }

    private static void AddRowTodo(ConsoleTable table, Issue issue)
    {
        table.AddRow(issue.Name, "", "", "", "", "");
    }
    private static void AddRowToReadyToTest(ConsoleTable table, Issue issue)
    {
        table.AddRow("", "", issue.Name , "", "", "");
    }
    private static void AddRowToTested(ConsoleTable table, Issue issue)
    {
        table.AddRow(issue.Name, "", "", "", "", "");
    }
    private static void AddRowCanceled(ConsoleTable table, Issue issue)
    {
        table.AddRow("", "", "", "", "", issue.Name);
    }

    private static void AddRowDone(ConsoleTable table, Issue issue)
    {
        table.AddRow("", "", "", issue.Name, "", "");
    }

    private static void AddRowInProgress(ConsoleTable table, Issue issue)
    {
        table.AddRow("", issue.Name, "", "", "", "");
    }

    public void DrawChart()
    {
        ChartControl chart = new ChartControl();
        chart.Width = 600;
        chart.Height = 600;
    }
}