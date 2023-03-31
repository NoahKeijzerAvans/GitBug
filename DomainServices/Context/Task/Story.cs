using Domain.Enums;
using DomainServices.Thread;

namespace DomainServices.Context.Task;

public class Story : Issue
{
    // ReSharper disable once UnusedAutoPropertyAccessor.Global
    public string? Narrative { get; set; }
    // ReSharper disable once UnusedAutoPropertyAccessor.Global
    public string? AcceptanceCriteria { get; set; }

    public Story(string name, string description, double storyPoints, Person assignedTo, Priority priority, string narrative, string acceptanceCriteria, List<Issue> subTasks) : base(name, description, storyPoints, assignedTo, priority, subTasks)
    {
        Narrative = narrative;
        AcceptanceCriteria = acceptanceCriteria;
    }

    public Story()
    {
        
    }
    public override string ToString()
    {
        return "Story";
    }
}