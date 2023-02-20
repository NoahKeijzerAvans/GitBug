using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainServices.Context;
using DomainServices.Context.Commands;
using DomainServices.Interfaces;
using DomainServices.Interfaces.Change;
using DomainServices.Utils;

namespace DomainServices.States.ChangesState
{
    public class WorkingDirectoryState : IChangesState
    {
        private ChangesTracker Tracker { get; set; }

        public WorkingDirectoryState()
        {
            Tracker = new ChangesTracker();
        }
        public WorkingDirectoryState(ChangesTracker tracker)
        {
            Tracker = tracker;
        }
        public void AddChange(Change change)
        {
            var changeAdd = new Dictionary<Change, IChangesState>()
            {
                { change, new StagingAreaState(Tracker) }
            };
            Tracker.Changes.Add(changeAdd);
            Tracker.State = new StagingAreaState(Tracker);
            Console.WriteLine("Changes added successfully");
        }

        public void CommitChanges(string description)
        {
            if (Tracker.Changes.Any())
            {
                var commit = new Commit(description, Tracker.Changes);
                Tracker.CurrentBranch.Commits.Add(commit, new HeadState(Tracker));
                Tracker.Changes = new List<Dictionary<Change, IChangesState>>();
                Tracker.State = new WorkingDirectoryState(Tracker);
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
                    Tracker.Branches.Add(new Branch(name!));
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
                Tracker.Branches.Add(new Branch(name));

            if (!Tracker.Changes.Any())
            {
                Tracker.CurrentBranch = Tracker.Branches.FirstOrDefault(b => b.Name.Equals(name))!;
                Console.WriteLine($"Current branch is {Tracker.CurrentBranch.Name}");;
            }else{
                Console.WriteLine("There are still uncommitted changes, would you like to bring the changes to the new branch? y/n");
                var answer = Console.ReadLine();
                if (!answer!.Equals("y")) return;
                Tracker.CurrentBranch = Tracker.Branches.FirstOrDefault(b => b.Name.Equals(name))!;
                Console.WriteLine($"Current branch is {Tracker.CurrentBranch.Name}");
            }
        }
    }
}
