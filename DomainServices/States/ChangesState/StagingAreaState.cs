using DomainServices.Context;
using DomainServices.Context.Commands;
using DomainServices.Interfaces.Change;
using DomainServices.Utils;

namespace DomainServices.States.ChangesState
{
    public class StagingAreaState : IChangesState
    {
        private Project Context { get; set; }

        public StagingAreaState(Project context)
        {
            Context = context;
        }

        public void AddChange(Change? change)
        {
            Context.Changes.Add(change);
            Console.WriteLine("Changes added successfully");
        }

        public void CommitChanges(string description)
        {
            if (Context.Changes.Any())
            {
                Context.Changes.ForEach(c =>
                {
                    c.State = new HeadState(Context);
                });
                var commit = new Commit(description, Context.Changes);
                Context.CurrentBranch.Commits.Add(commit);
                Context.Changes = new List<Change?>();
                Console.WriteLine("Changes committed successfully");

            }
            else
                Console.WriteLine("No changes to be committed");
        }

        public void PullToWorkingDirectory()
        {
            throw new NotImplementedException();
        }

        public void PushToRemote()
        {
            Console.WriteLine("Commit the changes first.");
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
            if (!Context.Changes.Any())
            {
                Context.Branches.Remove(branch);
                Console.WriteLine("Branch removed successfully");
            }
            else
            {
                Console.WriteLine(
                    "There are still uncommitted changes, would you still like to delete the branch? y/n");
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

            if (!Context.Changes.Any())
            {
                Context.CurrentBranch = Context.Branches.FirstOrDefault(b => b.Name.Equals(name))!;
                Console.WriteLine($"Current branch is {Context.CurrentBranch.Name}");
                ;
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
    }
}
