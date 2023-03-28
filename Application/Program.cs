// See https://aka.ms/new-console-template for more information

using Domain.Models;
using DomainServices.Context;
using DomainServices.Context.Pipeline;
using DomainServices.Context.Task;
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
problem.State = new ToDoState(problem);

project.Issues.Add(bug);
project.Issues.Add(problem);

var control = new CommandControl(project);
//var pipeline = new Pipeline();
//pipeline.Attach(new PackageStep());
//pipeline.Attach(new BuildStep());
//pipeline.Attach(new UtilityStep());
//pipeline.Attach(new AnalyseStep());
//pipeline.Attach(new TestStep());
//pipeline.Attach(new DeployStep());
//pipeline.Excecute();
 control.Listen();