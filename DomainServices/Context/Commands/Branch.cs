using DomainServices.Interfaces.Change;
using DomainServices.States.ChangesState;
using DomainServices.Utils;
using System.Diagnostics;

namespace DomainServices.Context.Commands
{
    public class Branch
    {
        public string Name { get; }
        public List<Change> Changes { get; set; }
        public List<Commit> Commits { get; }

        public Branch(string name, List<Commit> commits)
        {
            Name = name;
            Commits = commits;
            Changes = new List<Change>();
        }
        public Branch(string name)
        {
            Name = name;
            Commits = new List<Commit>();
            Changes = new List<Change>();
        }

        public IChangesState? GetCurrentState()
        {
            if (Changes.Any())
                return Changes.Last()!.State;
            return Commits.Any() ? Commits.Last().Changes.Last()!.State : null;
        }
    }
}
