using DomainServices.Interfaces.Change;
using DomainServices.States.ChangesState;
using DomainServices.Utils;
using System.Diagnostics;

namespace DomainServices.Context.Commands;
public class Change
{
    private Project Context { get; }
    public IChangesState State { get; set; }
    private dynamic _content;

    public Change(dynamic content, Project context)
    {
        Context = context;
        _content = content;
        State = new WorkingDirectoryState(context);
    }

    public Change(Project context)
    {
        Context = context;
        _content = new object();
        State = new WorkingDirectoryState(context);
    }
}

