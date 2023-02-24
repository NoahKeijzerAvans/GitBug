using DomainServices.Context;
using DomainServices.Context.Commands;
using DomainServices.Utils;

namespace DomainServices.Interfaces.Change;

public interface IChangesState
{
    public void CommitChanges(string description);
    public void AddChange(Context.Commands.Change? change);
    public void PushToRemote();
    public void CreateBranch();
    public void DeleteBranch(Branch branch);
    public void CheckoutBranch(string name);
    public void PullToWorkingDirectory();
    public void SetContext(Project context);
}
