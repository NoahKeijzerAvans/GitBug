using Domain.Enums;
using Domain.Models;

namespace DomainServices.Context.Task;

public class Incident : Issue
{
    public string? Summary { get; set; }
    public string? AffectedBusinessService { get; set; }
    public string? AffectedServer { get; set; }
    public Person? Reporter { get; set; }

    public Incident(string? name, string? description, Project? project, double storyPoints, Person? assignedTo, DateTime dateAdded, Priority priority, string? summary, string? affectedServer, string? affectedBusinessService, Person? reporter, List<Issue>? subTasks) : base(name, description, project, storyPoints, assignedTo, dateAdded, priority, subTasks)
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