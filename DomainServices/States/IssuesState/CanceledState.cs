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
        throw new InvalidOperationException();
    }

    public void SetIssueToInProgress()
    {
        throw new InvalidOperationException();
    }

    public void SetIssueToDone()
    {
        throw new InvalidOperationException();
    }

    public void SetIssueToReview()
    {
        throw new InvalidOperationException();
    }

    public void SetIssueToCanceled()
    {
        Console.WriteLine("This item is already on state Canceled");
        throw new InvalidOperationException();
    }
}