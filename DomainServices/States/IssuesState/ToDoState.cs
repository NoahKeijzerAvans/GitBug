using DomainServices.Context.Task;
using DomainServices.Interfaces.Issue;

namespace DomainServices.States.IssuesState;

public class ToDoState : IIssueState
{
    private Issue Context { get; }
    public ToDoState(Issue context)
    {
        Context = context;
    }
    public void SetIssueToDo()
    {
        throw new InvalidOperationException("This item is already on state Todo.");
    }

    public void SetIssueToInProgress()
    {
        Context.State = new InProgressState(Context);
    }

    public void SetIssueToDone()
    {
        throw new InvalidOperationException("Place the item in state In Progress first");
    }

    public void SetIssueToReadyForTesting()
    {
        throw new InvalidOperationException("Place the item in state In Progress first");
    }

    public void SetIssueToCanceled()
    {
        throw new InvalidOperationException("Place the item in state In Progress first");
    }

    public void SetIssueToTested()
    {
        throw new InvalidOperationException("Place the item in state In Progress first");
    }
}