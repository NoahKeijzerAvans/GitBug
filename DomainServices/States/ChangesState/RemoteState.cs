using DomainServices.Context.Commands;
using DomainServices.Interfaces.Change;
using DomainServices.Utils;

namespace DomainServices.States.ChangesState
{
    public class RemoteState : IChangesState
    {
        private ChangesTracker Tracker { get; set; }

        public RemoteState(ChangesTracker tracker)
        {
            Tracker = tracker;
        }
        public void AddChange(Change changes)
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

        public void SetContext(ChangesTracker context)
        {
            Tracker = context;
        }
        public void CreateBranch()
        {
            while (true)
            {
                Console.WriteLine("Please provide a name for the branch: ");
                var name = Console.ReadLine();
                if (name!.Any())
                {
                    Tracker.Branches.Add(new Branch(name!, Tracker));
                    CheckoutBranch(name!);
                }
                else
                    continue;
                break;
            }
        }

        public void DeleteBranch(Branch branch)
        {
            if (!Tracker.Changes.Any())
            {
                Tracker.Branches.Remove(branch);
                Console.WriteLine("Branch removed successfully");
            }
            else
            {
                Console.WriteLine("There are still uncommitted changes, would you still like to delete the branch? y/n");
                var answer = Console.ReadLine();
                if (!answer!.Equals("y")) return;
                Tracker.Branches.Remove(branch);
                Console.WriteLine("Branch removed successfully");
            }

        }

        public void CheckoutBranch(string name)
        {
            var branchExists = Tracker.Branches.Any(b => b.Name.Equals(name));
            if (!branchExists)
                Tracker.Branches.Add(new Branch(name, Tracker));

            if (!Tracker.Changes.Any()) return;
            {
                Console.WriteLine("There are still uncommitted changes, would you like to bring the changes to the new branch? y/n");
                var answer = Console.ReadLine();
                if (!answer!.Equals("y")) return;
                Tracker.CurrentBranch = Tracker.Branches.FirstOrDefault(b => b.Name.Equals(name))!;
                Console.WriteLine($"Current branch is {Tracker.CurrentBranch.Name}");
            }
        }
    }
}
