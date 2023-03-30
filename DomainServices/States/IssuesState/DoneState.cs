using DomainServices.Context.Task;
using DomainServices.Interfaces.Issue;

namespace DomainServices.States.IssuesState;

public class DoneState : IIssueState
{
    private Issue Context { get; }
    public DoneState(Issue context)
    {
        Context = context;
    }
    public void SetIssueToDo()
    {
        throw new InvalidOperationException("This item is already finalized");
    }

    public void SetIssueToInProgress()
    {
        throw new InvalidOperationException("This item is already finalized");
    }

    public void SetIssueToDone()
    {
        throw new InvalidOperationException("This item is already finalized");
    }

    public void SetIssueToCanceled()
    {
        throw new InvalidOperationException("This item is already finalized");
    }

    public void SetIssueToReadyForTesting()
    {
        throw new InvalidOperationException("This item is already finalized");
    }

    public void SetIssueToTested()
    {
        throw new InvalidOperationException("This item is already finalized");
    }
}