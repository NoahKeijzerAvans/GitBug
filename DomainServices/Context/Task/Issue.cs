using Domain.Enums;
using Domain.Models;
using DomainServices.Interfaces.Issue;
using DomainServices.States.IssuesState;

namespace DomainServices.Context.Task;

public abstract class Issue : IIssueStateable
{
    public string Name { get; set; }
    public string Description { get; }
    private Project _project;
    public double StoryPoints { get; }
    private List<Issue>? _subTasks;
    private Person? _assignedTo;
    private DateTime _dateAdded;
    private Priority? _priority;
    public IIssueState State { get; set; }

    protected Issue(string name, string description, Project project, double storyPoints, Person? assignedTo, DateTime dateAdded, Priority priority, List<Issue>? subTasks)
    {
        Name = name;
        Description = description;
        _project = project;
        StoryPoints = storyPoints;
        _assignedTo = assignedTo;
        _dateAdded = dateAdded;
        _priority = priority;
        _subTasks = subTasks;
        State = new ToDoState(this);
    }

    public void SetIssueToDo()
    {
        State.SetIssueToDo();
    }

    public void SetIssueToInProgress()
    {
        State.SetIssueToInProgress();
    }

    public void SetIssueToDone()
    {
        State.SetIssueToDone();
    }

    public void SetIssueToReview()
    {
        State.SetIssueToReview();
    }

    public void SetIssueToCanceled()
    {
        State.SetIssueToCanceled();
    }
}