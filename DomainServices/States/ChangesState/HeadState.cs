using DomainServices.Context;
using DomainServices.Context.VersionControl;
using DomainServices.Interfaces.Change;

namespace DomainServices.States.ChangesState;

public class HeadState : IChangesState
{
    private Project Context { get; set; }
    public HeadState(Project context)
    {
        Context = context;
    }

    public void AddChange(Change? change)
    {
        throw new InvalidOperationException("Cannot add changes in Head State");
    }

    public void CommitChanges(string description)
    {
        throw new InvalidOperationException("Cannot commit in Head State");
    }

    public void PullToWorkingDirectory()
    {
        Console.WriteLine("Pulled changes to Working Directory");
        Context.State = new WorkingDirectoryState(Context);
    }

    public void PushToRemote()
    {
        Console.WriteLine("Pushed commits to Remote");
        Context.State = new WorkingDirectoryState(Context);
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

        if (!Context.CurrentBranch.Changes.Any())
        {
            Context.CurrentBranch = Context.Branches.FirstOrDefault(b => b.Name.Equals(name))!;
            Console.WriteLine($"Current branch is {Context.CurrentBranch.Name}");
        }
        else
        {
            Console.WriteLine(
                "There are still uncommitted changes, would you like to bring the changes to the new branch? y/n");
            var answer = Console.ReadLine();
            if (!answer!.Equals("y")) return;
            Context.CurrentBranch = Context.Branches.FirstOrDefault(b => b.Name.Equals(name))!;
            Console.WriteLine($"Current branch is {Context.CurrentBranch.Name}");
        }
    }
    public override string ToString()
    {
        return "Head";
    }
}

