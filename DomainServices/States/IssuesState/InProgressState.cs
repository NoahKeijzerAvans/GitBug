using DomainServices.Context.Task;
using DomainServices.Interfaces.Issue;

namespace DomainServices.States.IssuesState;

public class InProgressState : IIssueState
{
    private Issue Context { get; }
    public InProgressState(Issue context)
    {
        Context = context;
    }
    public void SetIssueToDo()
    {
        throw new InvalidOperationException("Wrong direction of the flow.");
    }

    public void SetIssueToInProgress()
    {
        Console.WriteLine("This item is already on state In Progress");
        throw new InvalidOperationException();
    }

    public void SetIssueToDone()
    {
        throw new InvalidOperationException("Place the item in state Ready for Testing first");
    }

    public void SetIssueToCanceled()
    {
        Context.State = new CanceledState(Context);
    }

    public void SetIssueToReadyForTesting()
    {
        throw new InvalidOperationException("Place the item in state Ready for Testing first");
    }

    public void SetIssueToTested()
    {
        throw new InvalidOperationException("Place the item in state Ready for Testing first");
    }
}