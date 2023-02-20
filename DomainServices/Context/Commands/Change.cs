namespace DomainServices.Context.Commands;
public class Change
{
    public dynamic Content { get; }

    public Change(dynamic content)
    {
        Content = content;
    }

    public Change()
    {
        Content = new object();
    }
}

