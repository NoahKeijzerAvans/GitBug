using DomainServices.Context.Commands;
using DomainServices.Utils;
using System.Diagnostics;
using DomainServices.States.ChangesState;
using Domain.Models;
using DomainServices.Interfaces.Change;

namespace DomainServices.Context;

public class Project: IChangeStateable
{
    private Guid? _projectIdGuid;
    private string _name;
    private bool _isPrivate;
    private string _description;
    private List<Person> _contributors;
    public Branch CurrentBranch { get; set; }
    public List<Branch> Branches { get; }

    public IChangesState State { get; set; }

    public Project(string name, bool isPrivate, string description)
    {
        CurrentBranch = new Branch("master");
        Branches = new List<Branch>
        {
            CurrentBranch
        };
        State = CurrentBranch.GetCurrentState() ?? new WorkingDirectoryState(this);
        _projectIdGuid = Guid.NewGuid();
        _contributors = new List<Person>();
        _name = name;
        _isPrivate = isPrivate;
        _description = description;
    }
    public void CommitChanges(string description)
    {
        State.CommitChanges(description);
    }

    public void AddChange(Change? change)
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
        UpdateCurrentState();
    }

    public void CheckoutBranch(string name)
    {
        State.CheckoutBranch(name);
        UpdateCurrentState();
    }

    private void UpdateCurrentState()
    {
        State = CurrentBranch.GetCurrentState() ?? new WorkingDirectoryState(this);
    }
}