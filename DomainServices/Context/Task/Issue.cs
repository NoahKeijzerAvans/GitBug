using Domain.Enums;
using Domain.Models;
using DomainServices.Interfaces.Issue;
using DomainServices.States.IssuesState;

namespace DomainServices.Context.Task;

public abstract class Issue : IIssueStateable
{
    public string Name { get; set; }
    public string Description { get; set; }
    public Project Project { get; set; }
    public double StoryPoints { get; set; }
    public List<Issue>? SubTasks { get; set; }
    public Person? AssignedTo { get; set; }
    public DateTime DateAdded { get; set; }
    public Priority? Priority { get; set; }
    public IIssueState State { get; set; }

    protected Issue(string name, string description, Project project, double storyPoints, Person? assignedTo, DateTime dateAdded, Priority priority, List<Issue>? subTasks)
    {
        Name = name;
        Description = description;
        Project = project;
        StoryPoints = storyPoints;
        AssignedTo = assignedTo;
        DateAdded = dateAdded;
        Priority = priority;
        SubTasks = subTasks;
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