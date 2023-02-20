using DomainServices.Interfaces.Change;
using DomainServices.States.ChangesState;
using DomainServices.Utils;
using System.Diagnostics;

namespace DomainServices.Context.Commands
{
    public class Branch
    {
        public string Name { get; }
        public List<Commit> Commits { get; }
        public ChangesTracker Tracker { get; }
        public IChangesState State { get; }

        public Branch(string name, List<Commit> commits, ChangesTracker changesTracker)
        {
            Name = name;
            Commits = commits;
            Tracker = changesTracker;
            State = new WorkingDirectoryState(new ChangesTracker());
        }
        public Branch(string name, ChangesTracker changesTracker)
        {
            Name = name;
            Commits = new List<Commit>();
            Tracker = changesTracker;
            State = new WorkingDirectoryState(new ChangesTracker());
        }
    }
}
