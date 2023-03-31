using Domain.Enums;
using DomainServices.Thread;

namespace DomainServices.Context.Task;

public class Change : Issue
{
    // ReSharper disable once UnusedAutoPropertyAccessor.Global
    public string? Summary { get; set; }
    
    // ReSharper disable once UnusedAutoPropertyAccessor.Global
    public string? RequestType{ get; set; }

    public Change(string name, string description, double storyPoints, Person assignedTo, Priority priority, string summary, string requestType, List<Issue> subTasks) : base(name, description, storyPoints, assignedTo, priority, subTasks)
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