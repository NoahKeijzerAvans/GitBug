using DomainServices.Context.Task;
using DomainServices.Interfaces.Issue;

namespace DomainServices.States.IssuesState;

public class ReadyToTestState : IIssueState
{
    private Issue Context { get; }

    public ReadyToTestState(Issue context)
    {
        Context = context;
    }
    public void SetIssueToDo()
    {
        // According to the test it needs to be fixed
        // TODO: Send notification to Scrum Master & PO here
        Context.State = new ToDoState(Context);
    }

    public void SetIssueToInProgress()
    {
        throw new InvalidOperationException("Wrong direction of the flow.");
    }

    public void SetIssueToDone()
    {
        throw new InvalidOperationException("Place the item in state Tested first");
    }

    public void SetIssueToReadyForTesting()
    {
        throw new InvalidOperationException("This item is already on state Ready for testing");
    }

    public void SetIssueToCanceled()
    {
        Context.State = new CanceledState(Context);
    }

    public void SetIssueToTested()
    {
        Context.State = new TestedState(Context);
    }
}