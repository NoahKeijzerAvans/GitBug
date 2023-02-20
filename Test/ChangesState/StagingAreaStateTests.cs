using DomainServices.Context.Commands;
using DomainServices.Utils;

namespace Test.ChangesState;
public class StagingAreaStateTests
{
    private ChangesTracker _changeTracker;
    private Change _change;
    public StagingAreaStateTests()
    {
        _changeTracker = new ChangesTracker();
        _change = new Change(new object());
    }

    protected virtual void Setup()
    {
        // Arrange
        _changeTracker = new ChangesTracker();
        _changeTracker.State = new DomainServices.States.ChangesState.StagingAreaState(_changeTracker);
        _change = new Change(new object());
    }

    // Happy flow :)

    [Fact]
    public void Should_Change_State_To_Staging_Area_When_Changes_Are_First_Added()
    {
        // Arrange
        Setup();
        // Act
        _changeTracker.AddChange(_change);
        var sut = _changeTracker.Changes.First().Values.FirstOrDefault();

        // Assert
        Assert.IsType<DomainServices.States.ChangesState.StagingAreaState>(sut);
    }
    [Fact]
    public void Should_Change_State_To_Head_When_Changes_Are_Committed()
    {
        // Arrange
        Setup();

        // Act
        _changeTracker.AddChange(_change);
        _changeTracker.CommitChanges("Test");
        var sut = _changeTracker.CurrentBranch.Commits.First().Value;

        // Assert
        Assert.IsType<DomainServices.States.ChangesState.HeadState>(sut);
    }

    [Fact]
    public void Should_Change_State_Of_Changes_To_Head_But_Branch_Remains_On_Working_Directory_When_Changes_Are_Committed()
    {
        // Arrange
        Setup();

        // Act
        _changeTracker.AddChange(_change);
        _changeTracker.CommitChanges("Test");
        var sut = _changeTracker.State;

        // Assert
        Assert.IsType<DomainServices.States.ChangesState.WorkingDirectoryState>(sut);
    }


    // Unhappy flow :(
    [Fact]
    public void Should_Not_Change_State_When_Commit_Is_Called_With_No_Changes()
    {
        // Arrange
        Setup();

        // Act
        var sut = _changeTracker.State;

        // Assert
        Assert.IsType<DomainServices.States.ChangesState.StagingAreaState>(sut);
    }

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
}
