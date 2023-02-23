namespace DomainServices.Context.Commands;

public class Commit
{
    public List<Change?> Changes { get; }
    private string Description { get; }

    public Commit(string description, List<Change?> changes)
    {
        Changes = changes;
        Description = description;
    }
}
