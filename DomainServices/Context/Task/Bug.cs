using Domain;
using Domain.Enums;
using Domain.Models;
using DomainServices.Interfaces;

namespace DomainServices.Context.Task;

public class Bug: Issue
{
    private string Summary { get; set; }
    private Person RequestedBy { get; set; }
    
    public Bug(string name, string description, Project project, double storyPoints, Person? assignedTo, DateTime dateAdded, Priority priority,  string summary, Person requestedBy, List<Issue>? subTasks) : base(name, description, project, storyPoints, assignedTo, dateAdded, priority, subTasks)
    {
        Summary = summary;
        RequestedBy = requestedBy;
    }
}