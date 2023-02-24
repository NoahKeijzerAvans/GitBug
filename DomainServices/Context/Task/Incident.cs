using Domain.Enums;
using Domain.Models;

namespace DomainServices.Context.Task;

public class Incident : Issue
{
    private string _summary;
    private string _affectedBusinessService;
    private string _affectedServer;
    private Person _reporter;

    public Incident(string name, string description, Project project, double storyPoints, Person? assignedTo, DateTime dateAdded, Priority priority, string summary, string affectedServer, string affectedBusinessService, Person reporter, List<Issue>? subTasks) : base(name, description, project, storyPoints, assignedTo, dateAdded, priority, subTasks)
    {
        _summary = summary;
        _affectedServer = affectedServer;
        _affectedBusinessService = affectedBusinessService;
        _reporter = reporter;
    }
}