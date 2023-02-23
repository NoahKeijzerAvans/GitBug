using DomainServices.Context;
using DomainServices.Context.Commands;
using DomainServices.States.ChangesState;
using DomainServices.Utils;

namespace Test.ChangesState;
public class RemoteStateTests
{
    private Change _change;
    private Project _project;
    public RemoteStateTests()
    {
        _project = new Project("Test", false, "test environment");
        _project.State = new RemoteState(_project);
        _change = new Change(new object(), _project);
    }

    protected virtual void Setup()
    {
        // Arrange
        _project = new Project("Test", false, "test environment");
        _project.State = new RemoteState(_project);
        _change = new Change(new object(), _project);
    }

    // Unhappy flow :(

    [Fact]
    public void Should_Throw_Invalid_Operation_Exception_When_Push_To_Remote_Is_Called()
    {
        // Arrange
        Setup();
        // Act
        void TestCode() => _project.PushToRemote();
        // Assert
        Assert.Throws<InvalidOperationException>(TestCode);
    }
    [Fact]
    public void Should_Throw_Invalid_Operation_Exception_When_Add_Change_Is_Called()
    {
        // Arrange
        Setup();
        // Act
        void TestCode() => _project.AddChange(_change);
        // Assert
        Assert.Throws<InvalidOperationException>(TestCode);
    }
    [Fact]
    public void Should_Throw_Invalid_Operation_Exception_When_Commit_Changes_Is_Called()
    {
        // Arrange
        Setup();
        // Act
        void TestCode() => _project.CommitChanges("test");
        // Assert
        Assert.Throws<InvalidOperationException>(TestCode);
    }
}
