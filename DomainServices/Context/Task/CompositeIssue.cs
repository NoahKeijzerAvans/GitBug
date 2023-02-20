using Domain.Models;
using DomainServices.States.IssuesState;

namespace DomainServices.Context.Task;

public class CompositeIssue : Issue
{
    public readonly List<Issue> _issues = new();
    public CompositeIssue(string name, string description, Project project) : base(name, description, project, 0, null,
        DateTime.Now, 0, null)
    {
    }

    public void Add(Issue issue)
    {
        _issues.Add(issue);
    }

    public double TotalStoryPoints => _issues.Sum(i => i.StoryPoints);
    public double TotalCompletedStoryPoints => _issues.Sum(i =>
    {
        if (i.State.GetType() == typeof(DoneState))
            return i.StoryPoints;
        return 0;
    });
}