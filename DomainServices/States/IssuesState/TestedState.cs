using DomainServices.Context.Task;
using DomainServices.Interfaces.Issue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainServices.States.IssuesState;

public class TestedState : IIssueState
{
    private Issue Context { get; }

    public TestedState(Issue context)
    {
        Context = context;
    }
    public void SetIssueToCanceled()
    {
        Context.State = new CanceledState(Context);
    }

    public void SetIssueToDo()
    {
        throw new InvalidOperationException("Wrong direction of the flow.");
    }

    public void SetIssueToDone()
    {
        Context.State = new DoneState(Context);
    }

    public void SetIssueToInProgress()
    {
        throw new InvalidOperationException("Wrong direction of the flow.");
    }

    public void SetIssueToReadyForTesting()
    {
        throw new InvalidOperationException("Wrong direction of the flow.");
    }

    public void SetIssueToTested()
    {
        throw new InvalidOperationException("This item is already on state Tested");
    }
}
