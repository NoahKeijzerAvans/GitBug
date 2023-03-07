using DomainServices.Interfaces.Change;
using DomainServices.States.ChangesState;

namespace DomainServices.Context.VersionControl;
public class Change
{
    // ReSharper disable once UnusedAutoPropertyAccessor.Local
    private Project Context { get; }
    public IChangesState State { get; set; }
    // ReSharper disable once NotAccessedField.Local
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

