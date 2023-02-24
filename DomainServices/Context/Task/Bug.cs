using Domain.Enums;
using Domain.Models;

namespace DomainServices.Context.Task;

public class Bug : Issue
{
    public string? Summary { get; set; }
    public Person? RequestedBy { get; set; }

    public Bug(string? name, string? description, Project? project, double storyPoints, Person? assignedTo, DateTime dateAdded, Priority priority, string? summary, Person? requestedBy, List<Issue>? subTasks) : base(name, description, project, storyPoints, assignedTo, dateAdded, priority, subTasks)
    {
        Summary = summary;
        RequestedBy = requestedBy;
    }

    public Bug()
    {
        
    }
    public override string ToString()
    {
        return "Bug";
    }
}