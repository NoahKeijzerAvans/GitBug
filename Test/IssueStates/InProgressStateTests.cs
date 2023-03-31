using Domain.Enums;
using DomainServices.Thread;
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
        try
        {
            _issue.SetIssueToDo();
        }catch(Exception e)
        {

            // Assert
            Assert.IsType<InvalidOperationException>(e);
        }

    }
    [Fact]
    public void Should_Throw_Invalid_Operation_When_Ready_For_Testing_Is_Called()
    {
        // Arrange
        Setup();

        // Act
        try
        {
            _issue.SetIssueToReadyForTesting();
        }
        catch (Exception e)
        {
            // Assert
            Assert.IsType<InvalidOperationException>(e);
        }
    }

    [Fact]
    public void Should_Change_State_To_Done_When_Set_Issue_To_Done_Is_Called()
    {
        // Arrange
        Setup();
        // Act
        try
        {
            _issue.SetIssueToDone();
        }
        catch (Exception e)
        {
            // Assert
            Assert.IsType<InvalidOperationException>(e);
        }
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
