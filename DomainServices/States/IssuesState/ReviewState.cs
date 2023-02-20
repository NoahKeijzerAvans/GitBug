using DomainServices.Context.Task;
using DomainServices.Interfaces.Issue;

namespace DomainServices.States.IssuesState;

public class ReviewState : IIssueState
{
    private Issue Context { get; }

    public ReviewState(Issue context)
    {
        Context = context;
    }
    public void SetIssueToDo()
    {
        Context.State = new ToDoState(Context);
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
        Console.WriteLine("This item is already on state To Review");
        throw new InvalidOperationException();
    }

    public void SetIssueToCanceled()
    {
        Context.State = new CanceledState(Context);
    }
}