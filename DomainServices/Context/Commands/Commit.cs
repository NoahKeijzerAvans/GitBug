using DomainServices.Interfaces.Change;
using DomainServices.States.ChangesState;
using DomainServices.Utils;
using System.Diagnostics;

namespace DomainServices.Context.Commands;
public class Commit
{
    private List<Change> Changes { get; }
    public IChangesState State { get; set; }
    private string Description { get; }
    private ChangesTracker Tracker { get; }

    public Commit(string description, List<Change> changes, ChangesTracker tracker)
    {
        Changes = changes;
        Tracker = tracker;
        State = new HeadState(Tracker);
        Description = description;
        PushChangesToHead(changes);
    }

    private void PushChangesToHead(List<Change> changes)
    {
        changes.ForEach(c =>
        {
            c.State = new HeadState(Tracker);
        });
    }
}
