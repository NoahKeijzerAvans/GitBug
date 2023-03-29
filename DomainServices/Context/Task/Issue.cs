using Domain.Enums;
using DomainServices.Interfaces.Issue;
using DomainServices.States.IssuesState;
using DomainServices.Thread;

namespace DomainServices.Context.Task;

public abstract class Issue : IIssueStateable
{
    public string Name { get; set; }
    public string Description { get; set; }
    public double StoryPoints { get; set; }
    // ReSharper disable once NotAccessedField.Local
    private List<Issue> _subTasks;
    // ReSharper disable once UnusedAutoPropertyAccessor.Global
    public Person? AssignedTo { get; set; }
    // ReSharper disable once NotAccessedField.Local
    private DateTime _dateAdded;
    // ReSharper disable once UnusedAutoPropertyAccessor.Global
    public Priority? Priority { get; set; }
    public IIssueState? State { get; set; }

    protected Issue(string name, string description, double storyPoints, Person assignedTo, Priority priority, List<Issue> subTasks)
    {
        Name = name;
        Description = description;
        StoryPoints = storyPoints;
        AssignedTo = assignedTo;
        _dateAdded = DateTime.Now;
        Priority = priority;
        _subTasks = subTasks;
        State = new ToDoState(this);
    }

#pragma warning disable CS8618
    protected Issue()
#pragma warning restore CS8618
    {

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

    public void SetIssueToCanceled()
    {
        State!.SetIssueToCanceled();
    }

    public void SetIssueToTested()
    {
        State!.SetIssueToTested();
    }

    public void SetIssueToReadyForTesting()
    {
        State!.SetIssueToReadyForTesting();
    }
}