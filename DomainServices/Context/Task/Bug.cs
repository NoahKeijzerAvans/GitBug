using Domain.Enums;
using Domain.Models;

namespace DomainServices.Context.Task;

public class Bug : Issue
{
    // ReSharper disable once UnusedAutoPropertyAccessor.Global
    public string Summary { get; set; }
    // ReSharper disable once UnusedAutoPropertyAccessor.Global
    public Person RequestedBy { get; set; }

    public Bug(string name, string description, double storyPoints, Person assignedTo, Priority priority, string summary, Person requestedBy, List<Issue> subTasks) : base(name, description, storyPoints, assignedTo, priority, subTasks)
    {
        Summary = summary;
        RequestedBy = requestedBy;
    }

#pragma warning disable CS8618
    public Bug()
#pragma warning restore CS8618
    {
        
    }
    public override string ToString()
    {
        return "Bug";
    }
}