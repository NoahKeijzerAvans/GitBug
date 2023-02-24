using DomainServices.Context.Commands;

namespace DomainServices.Interfaces.Change;

public interface IChangeStateable
{
    public void CommitChanges(string description);
    public void AddChange(Context.Commands.Change? change);
    public void PushToRemote();
    public void CreateBranch();
    public void DeleteBranch(Branch branch);
    public void CheckoutBranch(string name);
    public void PullToWorkingDirectory();
}