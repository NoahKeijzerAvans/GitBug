using Domain.Enums;

namespace DomainServices.Context.Task;

public class Epic : Issue
{
    // ReSharper disable once UnusedAutoPropertyAccessor.Global
    public string Summary { get; set; }
    public Epic(string name, string description, Priority priority, string summary, List<Issue> subTasks) : base(name, description, 0, null!, priority, subTasks)
    {
        Summary = summary;
    }
    public override string ToString()
    {
        return "Epic";
    }

#pragma warning disable CS8618
    public Epic()
#pragma warning restore CS8618
    {
        
    }
}