// See https://aka.ms/new-console-template for more information

using Domain.Models;
using DomainServices.Context;
using DomainServices.Context.PipelineContext;
using DomainServices.Context.Task;
using DomainServices.Observer;
using DomainServices.Pipeline;
using DomainServices.Pipeline.Steps;
using DomainServices.States.IssuesState;
using DomainServices.Thread;
using DomainServices.Utils;

var noah = new Person(new MailNotification(), "Noah de Keijzer", "noah.cristiaan@gmail.com");
var tim = new Person(new MailNotification(), "Tim de Laater", "timdelaater@gmail.com");
var marcel = new Person(new SlackNotification(), "Marcel de Groot", "marceldegroot@gmail.com");

var project = new Project("GitBug")
{
    Contributors = new List<Person>
    {
        noah,
        tim,
        marcel
    },
};

var bug = new Bug
{
    AssignedTo = noah,
    Description = "Bug Found on git add task command", Name = "Console Cursor", StoryPoints = 3,
    Summary = "Cursor does not stay where it needs to be",
    RequestedBy = marcel
};
bug.State = new InProgressState(bug);

var problem = new Problem
{
    AssignedTo = tim,
    Description = "Factory Pattern not implemented yet", Name = "Factory Pattern", StoryPoints = 6,
    Summary = "Factory Pattern needs to be implemented for more repo types", RequestType = "Implementation"
};
problem.State = new InProgressState(bug);

var story = new Story
{
    AssignedTo = noah,
    Description = "Done",
    Name = "How do I implement the slack notification",
    StoryPoints = 6,
};
story.State = new DoneState(story);
project.GetCurrentSprint().AddIssue(bug);
project.GetCurrentSprint().AddIssue(problem);
project.GetCurrentSprint().AddIssue(story);

var control = new CommandControl(project);
var pipeline = new Pipeline();

pipeline.Subscribe(new PackageStep());
pipeline.Subscribe(new BuildStep());
pipeline.Subscribe(new UtilityStep());
pipeline.Subscribe(new AnalyseStep());
pipeline.Subscribe(new TestStep());
pipeline.Subscribe(new DeployStep());

//var thread = new IssueThread(problem, tim);
//thread.AddComment(noah, "Pretty Nasty Bug");
//thread.AddComment(marcel, "I got the following solution: {{ beautifull code here }}");
//thread.PrintThreadWithoutReplyOption(null);

//// pipeline.Update(null);
control.Listen();