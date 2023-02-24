using Domain.Enums;
using Domain.Models;

namespace DomainServices.Context.Task;

public class Problem : Issue
{
    public string? Summary { get; set; }
    public string? RequestType{ get; set; }
    public Problem(string? name, string? description, Project? project, double storyPoints, Person? assignedTo, DateTime dateAdded, Priority priority, string? summary, string? requestType, List<Issue>? subTasks) : base(name, description, project, storyPoints, assignedTo, dateAdded, priority, subTasks)
    {
        RequestType = requestType;
        Summary = summary;
    }

    public Problem()
    {
        
    }
    public override string ToString()
    {
        return "Problem";
    }
}