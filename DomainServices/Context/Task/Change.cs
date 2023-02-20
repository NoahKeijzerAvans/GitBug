using Domain.Enums;
using Domain.Models;

namespace DomainServices.Context.Task;

public class Change : Issue
{
    private string Summary { get; set; }
    private string RequestType { get; set; }

    public Change(string name, string description, Project project, double storyPoints, Person? assignedTo, DateTime dateAdded, Priority priority, string summary, string requestType, List<Issue>? subTasks) : base(name, description, project, storyPoints, assignedTo, dateAdded, priority, subTasks)
    {
        RequestType = requestType;
        Summary = summary;
    }
}