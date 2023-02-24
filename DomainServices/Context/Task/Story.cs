using Domain.Enums;
using Domain.Models;

namespace DomainServices.Context.Task;

public class Story : Issue
{
    private string _narrative;
    private string _acceptanceCriteria;

    public Story(string name, string description, Project project, double storyPoints, Person? assignedTo,
        DateTime dateAdded, Priority priority, string narrative, string acceptanceCriteria, List<Issue>? subTasks) : base(name, description, project, storyPoints, assignedTo, dateAdded, priority, subTasks)
    {
        _narrative = narrative;
        _acceptanceCriteria = acceptanceCriteria;
    }
}