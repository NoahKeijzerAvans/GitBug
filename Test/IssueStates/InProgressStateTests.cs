using Domain.Enums;
using Domain.Models;
using DomainServices.Context.Task;
using DomainServices.States.IssuesState;

namespace Test.IssueStates;
public sealed class InProgressStateTests
{
    private Issue _issue;
    public InProgressStateTests()
    {
        _issue = new Story("New Story", "Example", 5, new Person(), Priority.High, String.Empty,
            "when the task is finished the task is finished", new List<Issue>());
        _issue.State = new InProgressState(_issue);

    }

    private void Setup()
    {
        _issue = new Story("New Story", "Example",  5, new Person(),Priority.High, String.Empty,
            "when the task is finished the task is finished", new List<Issue>());
        _issue.State = new InProgressState(_issue);
    }
    [Fact]
    public void Should_Throw_Invalid_Operation_Exception_When_Set_In_Progress_Is_Called()
    {
        // Arrange
        Setup();
        // Act
        void TestCode() => _issue.SetIssueToInProgress();
        // Assert
        Assert.Throws<InvalidOperationException>(TestCode);
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
    public void Should_Change_State_To_Review_When_Set_Issue_To_Review_Is_Called()
    {
        // Arrange
        Setup();
        // Act
        _issue.SetIssueToReadyForTesting();
        var sut = _issue.State;

        // Assert
        Assert.IsType<ReadyToTestState>(sut);
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
