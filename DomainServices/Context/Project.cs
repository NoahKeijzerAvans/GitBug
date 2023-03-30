using DomainServices.States.ChangesState;
using DomainServices.Context.Task;
using DomainServices.Context.VersionControl;
using DomainServices.Interfaces.Change;
using Change = DomainServices.Context.VersionControl.Change;
using DomainServices.Thread;
using DomainServices.Factory;
using Microsoft.VisualBasic;
using Domain.Enums;
using System.Xml.Linq;

namespace DomainServices.Context;

public class Project: IChangeStateable
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