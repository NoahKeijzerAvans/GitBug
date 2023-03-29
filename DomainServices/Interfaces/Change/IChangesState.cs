using DomainServices.Context.VersionControl;

namespace DomainServices.Interfaces.Change;

public interface IChangesState
{
    public void CommitChanges(string description);
    public void AddChange(Context.VersionControl.Change change);
    public void PushToRemote();
    public void CreateBranch();
    public void DeleteBranch(Branch branch);
    public void CheckoutBranch(string name);
    public void PullToWorkingDirectory();
}
