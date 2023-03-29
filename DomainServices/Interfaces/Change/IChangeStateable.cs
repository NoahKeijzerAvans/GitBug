using DomainServices.Context.VersionControl;

namespace DomainServices.Interfaces.Change;

public interface IChangeStateable
{
    // ReSharper disable once UnusedMemberInSuper.Global
    public void CommitChanges(string description);
    // ReSharper disable once UnusedMemberInSuper.Global
    public void AddChange(Context.VersionControl.Change change);
    // ReSharper disable once UnusedMemberInSuper.Global
    public void PushToRemote();
    // ReSharper disable once UnusedMember.Global
    public void CreateBranch();
    // ReSharper disable once UnusedMember.Global
    public void DeleteBranch(Branch branch);
    // ReSharper disable once UnusedMemberInSuper.Global
    public void CheckoutBranch(string name);
    // ReSharper disable once UnusedMemberInSuper.Global
    public void PullToWorkingDirectory();
}