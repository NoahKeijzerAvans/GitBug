using Domain;
using Domain.Enums;
using Domain.Models;
using DomainServices.Context;
using DomainServices.Context.Task;
using DomainServices.States.IssuesState;
using DomainServices.Utils;

// var changeTracker = new ChangesTracker();
// var commandListener = new CommandControl(changeTracker);

// commandListener.Listen();

var compositeIssue = new CompositeIssue("Project example", "Example", new Project());

var problem = new Problem("New problem", "Example", new Project(), 1, new Person(), DateTime.Now, Priority.High, String.Empty, String.Empty, new List<Issue>());
var bug = new Bug("New Bug", "Example", new Project(), 6, new Person(), DateTime.Now, Priority.High, String.Empty, new Person(),new List<Issue>());
var story = new Story("New Story", "Example", new Project(), 5, new Person(), DateTime.Now, Priority.High, String.Empty,
    "when the task is finished the task is finished", new List<Issue>());

problem.SetIssueToDone();
story.SetIssueToInProgress();
bug.SetIssueToDone();

compositeIssue.Add(story);
compositeIssue.Add(problem);
compositeIssue.Add(bug);

var scrumBoard = new ScrumBoard(compositeIssue);
scrumBoard.Draw();
