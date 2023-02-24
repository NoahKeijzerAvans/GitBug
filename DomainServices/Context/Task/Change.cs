using Domain.Enums;
using Domain.Models;

namespace DomainServices.Context.Task;

public class Change : Issue
{
    public string? Summary { get; set; }
    public string? RequestType{ get; set; }

    public Change(string? name, string? description, Project? project, double storyPoints, Person? assignedTo, DateTime dateAdded, Priority priority, string? summary, string? requestType, List<Issue>? subTasks) : base(name, description, project, storyPoints, assignedTo, dateAdded, priority, subTasks)
    {
        RequestType = requestType;
        Summary = summary;
    }

    public Change()
    {
        
    }
    public override string ToString()
    {
        return "Change";
    }
}