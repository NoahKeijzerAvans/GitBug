using Domain.Enums;
using Domain.Models;

namespace DomainServices.Context.Task;

public class Story : Issue
{
    public string? Narrative { get; set; }
    public string? AcceptanceCriteria { get; set; }

    public Story(string? name, string? description, Project? project, double storyPoints, Person? assignedTo,
        DateTime dateAdded, Priority priority, string? narrative, string? acceptanceCriteria, List<Issue>? subTasks) : base(name, description, project, storyPoints, assignedTo, dateAdded, priority, subTasks)
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