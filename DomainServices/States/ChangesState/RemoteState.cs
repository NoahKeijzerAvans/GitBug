using DomainServices.Context;
using DomainServices.Context.VersionControl;
using DomainServices.Interfaces.Change;

namespace DomainServices.States.ChangesState;
public class RemoteState : IChangesState
{
    private Project Context { get; set; }

    public RemoteState(Project context)
    {
        Context = context;
    }
    public void AddChange(Change? changes)
    {
        throw new InvalidOperationException();
    }

    public void CommitChanges(string description)
    {
        throw new InvalidOperationException();
    }

    public void PullToWorkingDirectory()
    {
        throw new NotImplementedException();
    }

    public void PushToRemote()
    {
        throw new InvalidOperationException();
    }

    public void SetContext(Project context)
    {
        Context = context;
    }
    public void CreateBranch()
    {
        while (true)
        {
            Console.WriteLine("Please provide a name for the branch: ");
            var name = Console.ReadLine();
            if (name!.Any())
            {
                Context.Branches.Add(new Branch(name!));
                CheckoutBranch(name!);
            }
            else
                continue;
            break;
        }
    }

    public void DeleteBranch(Branch branch)
    {
        if (!Context.CurrentBranch.Changes.Any())
        {
            Context.Branches.Remove(branch);
            Console.WriteLine("Branch removed successfully");
        }
        else
        {
            Console.WriteLine("There are still uncommitted changes, would you still like to delete the branch? y/n");
            var answer = Console.ReadLine();
            if (!answer!.Equals("y")) return;
            Context.Branches.Remove(branch);
            Console.WriteLine("Branch removed successfully");
        }

    }

    public void CheckoutBranch(string name)
    {
        var branchExists = Context.Branches.Any(b => b.Name.Equals(name));
        if (!branchExists)
            Context.Branches.Add(new Branch(name));

        if (!Context.CurrentBranch.Changes.Any()) return;
        {
            Console.WriteLine("There are still uncommitted changes, would you like to bring the changes to the new branch? y/n");
            var answer = Console.ReadLine();
            if (!answer!.Equals("y")) return;
            Context.CurrentBranch = Context.Branches.FirstOrDefault(b => b.Name.Equals(name))!;
            Console.WriteLine($"Current branch is {Context.CurrentBranch.Name}");
        }
    }
}

