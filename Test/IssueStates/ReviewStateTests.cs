using Domain.Enums;
using Domain.Models;
using DomainServices.Context;
using DomainServices.Context.Task;
using DomainServices.Interfaces.Issue;
using DomainServices.States.IssuesState;

namespace Test.IssueStates;
public class ReviewStateTests
{
    private Issue _issue;
    public ReviewStateTests()
    {
        _issue = new Story("New Story", "Example", new Project("Test", true, "Test"), 5, new Person(), DateTime.Now, Priority.High, String.Empty,
            "when the task is finished the task is finished", new List<Issue>());
        _issue.State = new ReviewState(_issue);

    }
    internal virtual void Setup()
    {
        _issue = new Story("New Story", "Example", new Project("Test", true, "Test"), 5, new Person(), DateTime.Now, Priority.High, String.Empty,
            "when the task is finished the task is finished", new List<Issue>());
        _issue.State = new ReviewState(_issue);
    }
    [Fact]
    public void Should_Throw_Invalid_Operation_Exception_When_Set_To_Review_Is_Called()
    {
        // Arrange
        Setup();
        // Act
        void TestCode() => _issue.SetIssueToReview();
        // Assert
        Assert.Throws<InvalidOperationException>(TestCode);
    }

    [Fact]
    public void Should_Change_State_To_In_Progress_When_Set_Issue_To_In_Progress_Is_Called()
    {
        // Arrange
        Setup();
        // Act
        _issue.SetIssueToInProgress();
        var sut = _issue.State;

        // Assert
        Assert.IsType<InProgressState>(sut);
    }

    [Fact]
    public void Should_Change_State_To_Done_When_Set_Issue_To_Done_Is_Called()
    {
        // Arrange
        Setup();
        // Act
        _issue.SetIssueToDone();
        var sut = _issue.State;

        // Assert
        Assert.IsType<DoneState>(sut);
    }
    [Fact]
    public void Should_Change_State_To_Do_When_Set_Issue_To_Do_Is_Called()
    {
        // Arrange
        Setup();
        // Act
        _issue.SetIssueToDo();
        var sut = _issue.State;

        // Assert
        Assert.IsType<ToDoState>(sut);
    }
    [Fact]
    public void Should_Change_State_To_Canceled_When_Set_Issue_To_Canceled_Is_Called()
    {
        // Arrange
        Setup();
        // Act
        _issue.SetIssueToCanceled();
        var sut = _issue.State;

        // Assert
        Assert.IsType<CanceledState>(sut);
    }
}
