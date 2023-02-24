using Domain.Enums;
using Domain.Models;

namespace DomainServices.Context.Task;

public class Problem : Issue
{
    private string _summary;
    private string _requestType;
    public Problem(string name, string description, Project project, double storyPoints, Person? assignedTo, DateTime dateAdded, Priority priority, string summary, string requestType, List<Issue>? subTasks) : base(name, description, project, storyPoints, assignedTo, dateAdded, priority, subTasks)
    {
        _requestType = requestType;
        _summary = summary;
    }

}