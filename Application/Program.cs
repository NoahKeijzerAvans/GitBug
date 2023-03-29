// See https://aka.ms/new-console-template for more information

using Domain.Models;
using DomainServices.Context;
using DomainServices.Context.PipelineContext;
using DomainServices.Context.Task;
using DomainServices.Observer;
using DomainServices.Pipeline;
using DomainServices.Pipeline.Steps;
using DomainServices.States.IssuesState;
using DomainServices.Utils;

var project = new Project("GitBug", false, "SOFA3 Project")
{
    Contributors = new List<Person>
    {
        new ("timdelaater@gmail.com", "Tim", "de Laater"),
        new ("noah.cristiaan@gmail.com", "Noah", "de Keijzer"),
        new ("marceldegroot@gmail.com", "Marcel", "de Groot")
    }
};

var bug = new Bug
{
    AssignedTo = project.Contributors.FirstOrDefault(c => c.FullName.Equals("Noah de Keijzer")),
    Description = "Bug Found on git add task command", Name = "Console Cursor", StoryPoints = 3,
    Summary = "Cursor does not stay where it needs to be",
    RequestedBy = project.Contributors.First(c => c.FullName.Equals("Marcel de Groot"))
};

bug.State = new InProgressState(bug);
var problem = new Problem
{
    AssignedTo = project.Contributors.FirstOrDefault(c => c.FullName.Equals("Tim de Laater")),
    Description = "Factory Pattern not implemented yet", Name = "Factory Pattern", StoryPoints = 6,
    Summary = "Factory Pattern needs to be implemented for more repo types", RequestType = "Implementation"
};
bug.State = new InProgressState(bug);

var story = new Story
{
    AssignedTo = project.Contributors.FirstOrDefault(c => c.FullName.Equals("Noah de Keijzer")),
    Description = "Done",
    Name = "Done ",
    StoryPoints = 6,
};
story.State = new DoneState(story);

project.Issues.Add(bug);
project.Issues.Add(problem);
project.Issues.Add(story);

var control = new CommandControl(project);
var pipeline = new Pipeline();

pipeline.Subscribe(new PackageStep());
pipeline.Subscribe(new BuildStep());
pipeline.Subscribe(new UtilityStep());
pipeline.Subscribe(new AnalyseStep());
pipeline.Subscribe(new TestStep());
pipeline.Subscribe(new DeployStep());

var thread = new DomainServices.Observer.Thread();

IObserver mail = new MailNotification();
IObserver slak = new SlakNotification();

thread.Subscribe(mail);
thread.Subscribe(mail);

pipeline.Update(null);





// control.Listen();