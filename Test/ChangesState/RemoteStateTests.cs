using DomainServices.Context.Commands;
using DomainServices.Utils;

namespace Test.ChangesState;
public class RemoteStateTests
{
    private ChangesTracker _changeTracker;
    private Change _change;
    public RemoteStateTests()
    {
        _changeTracker = new ChangesTracker();
        _change = new Change(new object(), _changeTracker);
    }

    protected virtual void Setup()
    {
        // Arrange
        _changeTracker = new ChangesTracker();
        _changeTracker.State = new DomainServices.States.ChangesState.RemoteState(_changeTracker);
        _change = new Change(new object(), _changeTracker);
    }

    // Unhappy flow :(

    [Fact]
    public void Should_Throw_Invalid_Operation_Exception_When_Push_To_Remote_Is_Called()
    {
        // Arrange
        Setup();
        // Act
        void TestCode() => _changeTracker.PushToRemote();
        // Assert
        Assert.Throws<InvalidOperationException>(TestCode);
    }
    [Fact]
    public void Should_Throw_Invalid_Operation_Exception_When_Add_Change_Is_Called()
    {
        // Arrange
        Setup();
        // Act
        void TestCode() => _changeTracker.AddChange(_change);
        // Assert
        Assert.Throws<InvalidOperationException>(TestCode);
    }
    [Fact]
    public void Should_Throw_Invalid_Operation_Exception_When_Commit_Changes_Is_Called()
    {
        // Arrange
        Setup();
        // Act
        void TestCode() => _changeTracker.CommitChanges("test");
        // Assert
        Assert.Throws<InvalidOperationException>(TestCode);
    }
}
