using Domain.Enums;
using Domain.Models;
using DomainServices.Context.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainServices.States.IssuesState;

namespace Test.IssueComposite
{
    public class IssueCompositeTests
    {
        private CompositeIssue _compositeIssue;
        public IssueCompositeTests()
        {
            _compositeIssue = new CompositeIssue("Project example", "Example", new Project());

            var problem = new Problem("New problem", "Example", new Project(), 1, new Person(), DateTime.Now, Priority.High, String.Empty, String.Empty, new List<Issue>());
            var bug = new Bug("New Bug", "Example", new Project(), 1, new Person(), DateTime.Now, Priority.High, String.Empty, new Person(), new List<Issue>());
            var story = new Story("New Story", "Example", new Project(), 1, new Person(), DateTime.Now, Priority.High, String.Empty,
                "when the task is finished the task is finished", new List<Issue>());

            _compositeIssue.Add(story);
            _compositeIssue.Add(problem);
            _compositeIssue.Add(bug);
        }
        internal virtual void Setup()
        {
            _compositeIssue = new CompositeIssue("Project example", "Example", new Project());

            var problem = new Problem("New problem", "Example", new Project(), 1, new Person(), DateTime.Now, Priority.High, String.Empty, String.Empty, new List<Issue>());
            var bug = new Bug("New Bug", "Example", new Project(), 1, new Person(), DateTime.Now, Priority.High, String.Empty, new Person(), new List<Issue>());
            var story = new Story("New Story", "Example", new Project(), 1, new Person(), DateTime.Now, Priority.High, String.Empty,
                "when the task is finished the task is finished", new List<Issue>());

            _compositeIssue.Add(story);
            _compositeIssue.Add(problem);
            _compositeIssue.Add(bug);
        }

        [Fact]
        public void Should_Return_3_Total_Story_Points()
        {
            // Arrange
            Setup();
            // Act
            var sut = _compositeIssue.TotalStoryPoints;

            // Assert
            Assert.Equal(3, sut);
        }
        [Fact]
        public void Should_Return_2_Completed_Story_Points()
        {
            // Arrange
            _compositeIssue = new CompositeIssue("Project example", "Example", new Project());

            var problem = new Problem("New problem", "Example", new Project(), 1, new Person(), DateTime.Now, Priority.High, String.Empty, String.Empty, new List<Issue>());
            var bug = new Bug("New Bug", "Example", new Project(), 1, new Person(), DateTime.Now, Priority.High, String.Empty, new Person(), new List<Issue>());
            var story = new Story("New Story", "Example", new Project(), 1, new Person(), DateTime.Now, Priority.High, String.Empty,
                "when the task is finished the task is finished", new List<Issue>());
            story.State = new DoneState(story);
            bug.State = new DoneState(story);

            _compositeIssue.Add(story);
            _compositeIssue.Add(problem);
            _compositeIssue.Add(bug);

            // Act
            var sut = _compositeIssue.TotalCompletedStoryPoints;

            // Assert
            Assert.Equal(2, sut);
        }
        [Fact]
        public void Should_Add_Sucessfully_If_Bug()
        {
            // Arrange
            _compositeIssue = new CompositeIssue("Project example", "Example", new Project());
            var bug = new Bug("New Bug", "Example", new Project(), 1, new Person(), DateTime.Now, Priority.High, String.Empty, new Person(), new List<Issue>());

            // Act
            _compositeIssue.Add(bug);
            var sut = _compositeIssue._issues.Count;
            // Assert
            Assert.Equal(1, sut);
        }
        [Fact]
        public void Should_Add_Sucessfully_If_Change()
        {
            // Arrange
            _compositeIssue = new CompositeIssue("Project example", "Example", new Project());
            var change = new Change("New Change", "Example", new Project(), 1, new Person(), DateTime.Now, Priority.High, String.Empty, String.Empty, new List<Issue>());

            // Act
            _compositeIssue.Add(change);
            var sut = _compositeIssue._issues.Count;
            // Assert
            Assert.Equal(1, sut);
        }
        [Fact]
        public void Should_Add_Sucessfully_If_Epic()
        {
            // Arrange
            _compositeIssue = new CompositeIssue("Project example", "Example", new Project());
            var epic = new Epic("New Epic", "Example",new Project(), DateTime.Now, Priority.High, String.Empty, String.Empty, new List<Issue>());

            // Act
            _compositeIssue.Add(epic);
            var sut = _compositeIssue._issues.Count;
            // Assert
            Assert.Equal(1, sut);
        }

        [Fact]
        public void Should_Add_Sucessfully_If_Incident()
        {
            // Arrange
            _compositeIssue = new CompositeIssue("Project example", "Example", new Project());
            var incident = new Incident("New Incident", "Example", new Project(), 1, new Person(), DateTime.Now, Priority.High, String.Empty, String.Empty, String.Empty, new Person(), new List<Issue>());

            // Act
            _compositeIssue.Add(incident);
            var sut = _compositeIssue._issues.Count;
            // Assert
            Assert.Equal(1, sut);
        }
        [Fact]
        public void Should_Add_Sucessfully_If_Problem()
        {
            // Arrange
            _compositeIssue = new CompositeIssue("Project example", "Example", new Project());
            var problem = new Problem("New Problem", "Example", new Project(), 1, new Person(), DateTime.Now, Priority.High, String.Empty, String.Empty, new List<Issue>());

            // Act
            _compositeIssue.Add(problem);
            var sut = _compositeIssue._issues.Count;
            // Assert
            Assert.Equal(1, sut);
        }
        [Fact]
        public void Should_Add_Sucessfully_If_Story()
        {
            // Arrange
            _compositeIssue = new CompositeIssue("Project example", "Example", new Project());
            var story = new Story("New Problem", "Example", new Project(), 1, new Person(), DateTime.Now, Priority.High, String.Empty, String.Empty, new List<Issue>());

            // Act
            _compositeIssue.Add(story);
            var sut = _compositeIssue._issues.Count;
            // Assert
            Assert.Equal(1, sut);
        }
    }
}
