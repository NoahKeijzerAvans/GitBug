using DomainServices.Context.Task;
using DomainServices.Interfaces.Issue;

namespace DomainServices.States.IssuesState;

public class CanceledState : IIssueState
{
    private Issue Context { get; }

    public CanceledState(Issue context)
    {
        Context = context;
    }

    public void SetIssueToDo()
    {
        throw new InvalidOperationException("This item is canceled");
    }

    public void SetIssueToInProgress()
    {
        throw new InvalidOperationException("This item is canceled");
    }

    public void SetIssueToDone()
    {
        throw new InvalidOperationException("This item is canceled");
    }

    public void SetIssueToCanceled()
    {
        throw new InvalidOperationException("This item is already on state Canceled");
    }
    public void SetIssueToTested()
    {
        throw new InvalidOperationException("This item is canceled");
    }

    public void SetIssueToReadyForTesting()
    {
        throw new InvalidOperationException("This item is canceled");
    }
}