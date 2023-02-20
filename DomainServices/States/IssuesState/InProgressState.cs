using DomainServices.Context.Task;
using DomainServices.Interfaces;
using DomainServices.Interfaces.Issue;

namespace DomainServices.States.IssuesState;

public class InProgressState: IIssueState
{
    private Issue Context { get; }
    public InProgressState(Issue context)
    {
        Context = context;
    }
    public void SetIssueToDo()
    {
        Context.State = new ToDoState(Context);
    }

    public void SetIssueToInProgress()
    {
        Console.WriteLine("This item is already on state In Progress");
        throw new InvalidOperationException();
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