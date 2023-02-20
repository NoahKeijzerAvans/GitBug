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
        throw new InvalidOperationException();
    }

    public void SetIssueToInProgress()
    {
        throw new InvalidOperationException();
    }

    public void SetIssueToDone()
    {
        Console.WriteLine("This item is already finalized");
        throw new InvalidOperationException();
    }

    public void SetIssueToReview()
    {
        throw new InvalidOperationException();
    }

    public void SetIssueToCanceled()
    {
        Console.WriteLine("This item is already finalized");
        throw new InvalidOperationException();
    }
}