using DomainServices.Interfaces.Change;

namespace DomainServices.Context.VersionControl
{
    public class Branch
    {
        public string Name { get; }
        public Dictionary<Commit, IChangesState> Commits { get; }

        public Branch(string name, Dictionary<Commit, IChangesState> commits)
        {
            Name = name;
            Commits = commits;
        }
        public Branch(string name)
        {
            Name = name;
            Commits = new Dictionary<Commit, IChangesState>();
        }
    }
}
