using Domain.Enums;
using Domain.Models;

namespace DomainServices.Context.Task;
public class Incident : Issue
{
    // ReSharper disable once UnusedAutoPropertyAccessor.Global
    public string? Summary { get; set; }
    // ReSharper disable once UnusedAutoPropertyAccessor.Global
    public string? AffectedBusinessService { get; set; }
    // ReSharper disable once UnusedAutoPropertyAccessor.Global
    public string? AffectedServer { get; set; }
    // ReSharper disable once UnusedAutoPropertyAccessor.Global
    public Person? Reporter { get; set; }

    public Incident(string name, string description, double storyPoints, Person? assignedTo, Priority priority, string summary, string? affectedServer, string? affectedBusinessService, Person? reporter, List<Issue> subTasks) : base(name, description, storyPoints, assignedTo!, priority, subTasks)
    {
        Summary = summary;
        AffectedServer = affectedServer;
        AffectedBusinessService = affectedBusinessService;
        Reporter = reporter;
    }

    public Incident()
    {
        
    }
    public override string ToString()
    {
        return "Incident";
    }
}