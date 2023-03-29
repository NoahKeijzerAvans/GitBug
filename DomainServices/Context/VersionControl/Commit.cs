namespace DomainServices.Context.VersionControl;

public class Commit
{
    public List<Change> Changes { get; }
    // ReSharper disable once NotAccessedField.Local
    private string _description;

    public Commit(string description, List<Change> changes)
    {
        Changes = changes;
        _description = description;
    }
}
