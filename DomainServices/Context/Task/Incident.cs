using Domain;
using Domain.Enums;
using Domain.Models;
using DomainServices.Interfaces;

namespace DomainServices.Context.Task;

public class Incident: Issue
{
    private string Summary { get; set; }
    private string AffectedBusinessService { get; set; }
    private string AffectedServer { get; set; }
    private Person Reporter { get; set; }
    
    public Incident(string name, string description, Project project, double storyPoints, Person? assignedTo, DateTime dateAdded, Priority priority, string summary, string affectedServer, string affectedBusinessService, Person reporter, List<Issue>? subTasks) : base(name, description, project, storyPoints, assignedTo, dateAdded, priority, subTasks)
    {
        Summary = summary;
        AffectedServer = affectedServer;
        AffectedBusinessService = affectedBusinessService;
        Reporter = reporter;
    }
}