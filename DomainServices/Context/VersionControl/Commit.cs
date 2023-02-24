using DomainServices.Interfaces.Change;
using DomainServices.States.ChangesState;

namespace DomainServices.Context.VersionControl;
public class Commit
{
    private List<Dictionary<Change, IChangesState>> Changes { get; }
    private string Description { get; }

    public Commit(string description, List<Dictionary<Change, IChangesState>> changes)
    {
        Description = description;
        Changes = PushChangesToHead(changes);
    }

    private static List<Dictionary<Change, IChangesState>> PushChangesToHead(IEnumerable<Dictionary<Change, IChangesState>> changes)
    {
        return (from changesToHead in changes from change in changesToHead.Keys select new Dictionary<Change, IChangesState> { { change, new HeadState() } }).ToList();
    }
}
