using ConsoleTables;
using DomainServices.Context.Task;
using DomainServices.States.IssuesState;
using Syncfusion.Blazor.Data;

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

        var table = new ConsoleTable("To Do", "In Progress", "Ready to Test", "Tested", "Done", "Canceled");

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
        table.AddRow("", "", issue.Name, "", "", "");
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
        int[] storyPoints = { 10, 9, 7, 6, 4, 2, 0 };
        int numDays = 7;
        int numTasks = Issues.Issues.Count;
        // Step 1: Define the size of the array
        int[,] burndownChart = new int[numDays, storyPoints.Max()];

        // Step 2: Initialize the array with zeros
        for (int i = 0; i < numDays; i++)
        {
            for (int j = 0; j < storyPoints.Max(); j++)
            {
                burndownChart[i, j] = 0;
            }
        }


        // Step 3: Plot the story points on the array
        for (int i = 0; i < numDays; i++)
        {
            int storyPointsRemaining = storyPoints[i];
            if (storyPointsRemaining >= 1) // Make sure the index is within bounds
            {
                burndownChart[i, storyPointsRemaining - 1] = storyPointsRemaining;
            }
        }

        // Step 4: Print the burndown chart
        Console.WriteLine("Burndown Chart");
        Console.WriteLine();

        // Print the chart and y axis labels
        for (int j = storyPoints.Max() - 1; j >= 0; j--)
        {
            var numberLength = (j + 1).ToString().Length;
            var spaces = "";

            if (numberLength == 1)
                spaces = "  ";
            if (numberLength == 2)
                spaces = " ";
            if (numberLength == 3)
                spaces = "";

            Console.Write((j + 1).ToString() + spaces + "|" + "\t");
            int prevStoryPoints = 0;
            for (int i = 0; i < numDays; i++)
            {
                if (burndownChart[i, j] == 0)
                {
                    Console.Write(" \t"); // empty space
                }
                else
                {
                    Console.Write("* (" + burndownChart[i, j].ToString() + ")\t");

                    // Draw a line connecting the * characters
                    if (prevStoryPoints > 0)
                    {
                        if (prevStoryPoints > burndownChart[i, j])
                        {
                            for (int k = burndownChart[i, j]; k < prevStoryPoints; k++)
                            {
                                Console.Write(" \t");
                            }
                            Console.Write("\\\t");
                        }
                        else if (prevStoryPoints < burndownChart[i, j])
                        {
                            for (int k = prevStoryPoints; k < burndownChart[i, j]; k++)
                            {
                                Console.Write(" \t");
                            }
                            Console.Write("/\t");
                        }
                        else
                        {
                            Console.Write(" \t\\\t");
                        }
                    }

                    prevStoryPoints = burndownChart[i, j];
                }
            }
            Console.WriteLine();
        }
        // Print the x axis labels
        for (int i = 1; i <= burndownChart.Length; i++)
        {
            Console.Write("_");
        }
        Console.WriteLine();
        Console.Write("Day\t");
        for (int i = 1; i <= numDays; i++)
        {
            Console.Write(i.ToString() + "\t");
        }
        Console.WriteLine();
    }

    public void EffortPerDeveloper()
    {
        var efforts = new Dictionary<string, double>();
        var groupedIssues = Issues.Issues
        .GroupBy(u => u.AssignedTo)
        .Select(grp => grp.ToList())
        .ToList();

        var effort = 0.0;
        groupedIssues.ForEach(i =>
        {
            i.ForEach(j => effort =+ j.StoryPoints);
        });

    }
}