using DomainServices.States.IssuesState;

namespace DomainServices.Context.Task;

public class CompositeIssue : Issue
{
    public readonly List<Issue> Issues = new();
    public CompositeIssue(string? name, string? description, Project? project) : base(name, description, project, 0, null,
        DateTime.Now, 0, null)
    {
    }

    public void Add(Issue issue)
    {
        if(State == null)
          issue.State = new ToDoState(this);
        Issues.Add(issue);
    }

    public double TotalStoryPoints => Issues.Sum(i => i.StoryPoints);
    public double TotalCompletedStoryPoints => Issues.Sum(i =>
    {
        if (i.State!.GetType() == typeof(DoneState))
            return i.StoryPoints;
        return 0;
    });
}