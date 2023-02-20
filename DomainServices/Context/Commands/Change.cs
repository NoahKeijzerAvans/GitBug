using DomainServices.Interfaces.Change;
using DomainServices.States.ChangesState;
using DomainServices.Utils;
using System.Diagnostics;

namespace DomainServices.Context.Commands;
public class Change
{
    public IChangesState State { get; set; }
    public ChangesTracker Tracker { get; }
    public dynamic Content { get; }

    public Change(dynamic content, ChangesTracker tracker)
    {
        Content = content;
        Tracker = tracker;
        State = new WorkingDirectoryState(Tracker);
    }

    public Change(ChangesTracker tracker)
    {
        Tracker = tracker;
        Content = new object();
        State = new WorkingDirectoryState();
    }
}

