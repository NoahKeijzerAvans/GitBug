using Domain.Enums;
using DomainServices.Thread;

namespace DomainServices.Context.Task;

public class Problem : Issue
{
    // ReSharper disable once UnusedAutoPropertyAccessor.Global
    public string Summary { get; set; }
    // ReSharper disable once UnusedAutoPropertyAccessor.Global
    public string RequestType { get; set; }
    public Problem(string name, string description, double storyPoints, Person assignedTo, Priority priority, string summary, string requestType, List<Issue> subTasks) : base(name, description, storyPoints, assignedTo, priority, subTasks)
    {
        RequestType = requestType;
        Summary = summary;
    }

#pragma warning disable CS8618
    public Problem()
#pragma warning restore CS8618
    {
        
    }
    public override string ToString()
    {
        return "Problem";
    }
}