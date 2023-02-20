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
        Console.WriteLine("This item is already on state Todo.");
        throw new InvalidOperationException();
    }

    public void SetIssueToInProgress()
    {
        Context.State = new InProgressState(Context);
    }

    public void SetIssueToDone()
    {
        Context.State = new DoneState(Context);
    }

    public void SetIssueToReview()
    {
        Context.State = new ReviewState(Context);
    }

    public void SetIssueToCanceled()
    {
        Context.State = new CanceledState(Context);
    }
}