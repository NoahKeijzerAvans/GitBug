namespace DomainServices.Context.Commands;

public class Commit
{
    public List<Change> Changes { get; }
    private string _description;

    public Commit(string description, List<Change> changes)
    {
        Changes = changes;
        _description = description;
    }
}
