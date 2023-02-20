using DomainServices.Context.Commands;
using DomainServices.Interfaces.Change;
using DomainServices.States.ChangesState;

namespace DomainServices.Utils;

public class ChangesTracker : IChangeStateable
{
    public Branch CurrentBranch { get; set; }
    public List<Branch> Branches { get; set; }
    public List<Change> Changes { get; set; }
    public IChangesState State { get; set; }

    public ChangesTracker()
    {
        CurrentBranch = new Branch("master", this);
        Branches = new List<Branch> { CurrentBranch };
        Changes = new List<Change>();
        State = new WorkingDirectoryState(this);
    }

    public ChangesTracker(IChangesState state)
    {
        CurrentBranch = new Branch("master",this);
        Branches = new List<Branch> { CurrentBranch };
        Changes = new List<Change>();
        State = state;
    }

    public void CommitChanges(string description)
    {
        State.CommitChanges(description);
    }

    public void AddChange(Change change)
    {
        State.AddChange(change);
    }

    public void PushToRemote()
    {
        State.PushToRemote();
    }

    public void PullToWorkingDirectory()
    {
        State.PullToWorkingDirectory();
    }

    public void CreateBranch()
    {
        State.CreateBranch();
    }

    public void DeleteBranch(Branch branch)
    {
        State.DeleteBranch(branch);
    }

    public void CheckoutBranch(string name)
    {
        State.CheckoutBranch(name);
    }

    public Branch GetCurrentBranch()
    {
        return CurrentBranch;
    }
}
