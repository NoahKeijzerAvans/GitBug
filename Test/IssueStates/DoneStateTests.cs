using Domain.Enums;
using Domain.Models;
using DomainServices.Context.Task;
using DomainServices.States.IssuesState;

namespace Test.IssueStates;
public sealed class DoneStateTests
{
    private Issue _issue;
    public DoneStateTests()
    {
        _issue = new Story("New Story", "Example", 5, new Person(), Priority.High, String.Empty,
            "when the task is finished the task is finished", new List<Issue>());
        _issue.State = new DoneState(_issue);

    }

    private void Setup()
    {
        _issue = new Story("New Story", "Example", 5, new Person(), Priority.High, String.Empty,
            "when the task is finished the task is finished", new List<Issue>());
        _issue.State = new DoneState(_issue);
    }

    // Happy flow :)

    [Fact]
    public void Should_Throw_Invalid_Operation_Exception_When_Set_To_Do_Is_Called()
    {
        // Arrange
        Setup();
        // Act
        void TestCode() => _issue.SetIssueToDo();
        // Assert
        Assert.Throws<InvalidOperationException>(TestCode);
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
    public void Should_Throw_Invalid_Operation_Exception_When_Set_Issue_To_Done_Is_Called()
    {
        // Arrange
        Setup();
        // Act
        void TestCode() => _issue.SetIssueToDone();
        // Assert
        Assert.Throws<InvalidOperationException>(TestCode);
    }
    [Fact]
    public void Should_Throw_Invalid_Operation_Exception_When_Set_To_Review_Is_Called()
    {
        // Arrange
        Setup();
        // Act
        void TestCode() => _issue.SetIssueToReadyForTesting();
        // Assert
        Assert.Throws<InvalidOperationException>(TestCode);
    }
    [Fact]
    public void Should_Throw_Invalid_Operation_Exception_When_Set_Canceled_Is_Called()
    {
        // Arrange
        Setup();
        // Act
        void TestCode() => _issue.SetIssueToCanceled();
        // Assert
        Assert.Throws<InvalidOperationException>(TestCode);
    }
}
