using Domain.Enums;
using Domain.Models;
using DomainServices.Interfaces.Issue;
using DomainServices.States.IssuesState;

namespace DomainServices.Context.Task;

public abstract class Issue : IIssueStateable
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    private Project? _project;
    public double StoryPoints { get; set; }
    private List<Issue>? _subTasks;
    public Person? AssignedTo { get; set; }
    private DateTime _dateAdded;
    public Priority? Priority { get; set; }
    public IIssueState? State { get; set; }

    protected Issue(string? name, string? description, Project? project, double storyPoints, Person? assignedTo, DateTime dateAdded, Priority priority, List<Issue>? subTasks)
    {
        Name = name;
        Description = description;
        _project = project;
        StoryPoints = storyPoints;
        AssignedTo = assignedTo;
        _dateAdded = DateTime.Now;
        Priority = priority;
        _subTasks = subTasks;
        State = new ToDoState(this);
    }

    protected Issue()
    {
        _dateAdded = DateTime.Now;
    }

    public void SetIssueToDo()
    {
        State!.SetIssueToDo();
    }

    public void SetIssueToInProgress()
    {
        State!.SetIssueToInProgress();
    }

    public void SetIssueToDone()
    {
        State!.SetIssueToDone();
    }

    public void SetIssueToReview()
    {
        State!.SetIssueToReview();
    }

    public void SetIssueToCanceled()
    {
        State!.SetIssueToCanceled();
    }
}