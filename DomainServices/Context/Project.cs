using DomainServices.States.ChangesState;
using DomainServices.Context.Task;
using DomainServices.Context.VersionControl;
using DomainServices.Interfaces.Change;
using DomainServices.Thread;
using DomainServices.Factory;
using Domain.Enums;
using Change = DomainServices.Context.VersionControl.Change;

namespace DomainServices.Context;

public class Project : IChangeStateable
{
    private string Name { get; set; }
    private ReleaseSprintFactory ReleaseSprintFactory { get; set; }
    private PartialProductSprintFactory PartialProductSprintFactory { get; set; }
    public List<Sprint> Sprints { get; set; }
    public List<Person> Contributors { get; init; }
    public Branch CurrentBranch { get; set; }
    public List<Branch> Branches { get; }
    public IChangesState State { get; set; }
    public Project(string name)
    {
        Name = name;
        ReleaseSprintFactory = new ReleaseSprintFactory();
        PartialProductSprintFactory = new PartialProductSprintFactory();
        CurrentBranch = new Branch("master");
        Branches = new List<Branch>
        {
            CurrentBranch
        };
        Sprints = new List<Sprint>();
        State = CurrentBranch.GetCurrentState() ?? new WorkingDirectoryState(this);
        Contributors = new List<Person>();
    }
    public void CreateSprint()
    {
        Console.WriteLine("Create a Partial Product or Release Sprint? p/r");
        var answer = Console.ReadLine();
        if (answer!.Equals("p"))
            Sprints.Add(PartialProductSprintFactory.CreateSprint($"Sprint {Sprints.Count + 1}"));
        else if (answer!.Equals("f"))
            Sprints.Add(ReleaseSprintFactory.CreateSprint($"Sprint {Sprints.Count + 1}"));
    }
    public Sprint GetCurrentSprint()
    {
        return Sprints.First(s => s.SprintStatus.Equals(SprintStatus.INPROGRESS));
    }

    public void CommitChanges(string description)
    {
        GetCurrentState().CommitChanges(description);
    }

    public void AddChange(Change change)
    {
        GetCurrentState().AddChange(change);
    }

    public void PushToRemote()
    {
        GetCurrentState().PushToRemote();
    }

    public void PullToWorkingDirectory()
    {
        GetCurrentState().PullToWorkingDirectory();
    }

    public void CreateBranch()
    {
        GetCurrentState().CreateBranch();
    }

    public void DeleteBranch(Branch branch)
    {
        GetCurrentState().DeleteBranch(branch);
        UpdateCurrentState();
    }

    public void CheckoutBranch(string name)
    {
        GetCurrentState().CheckoutBranch(name);
        UpdateCurrentState();
    }
    public IChangesState GetCurrentState()
    {
        var currentState = CurrentBranch.GetCurrentState();
        if (currentState == null || currentState.GetType() == typeof(RemoteState))
            return State;
        return CurrentBranch.GetCurrentState()!;
    }
    private void UpdateCurrentState()
    {
        State = CurrentBranch.GetCurrentState() ?? new WorkingDirectoryState(this);
    }
}