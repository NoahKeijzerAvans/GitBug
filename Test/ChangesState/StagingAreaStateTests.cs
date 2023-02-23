using DomainServices.Context;
using DomainServices.Context.Commands;
using DomainServices.States.ChangesState;
using DomainServices.Utils;

namespace Test.ChangesState;
public class StagingAreaStateTests
{
    private Change _change;
    private Project _project;
    public StagingAreaStateTests()
    {
        _project = new Project("Test", false, "test environment");
        _project.State = new StagingAreaState(_project);
        _change = new Change(new object(), _project);
    }

    protected virtual void Setup()
    {
        // Arrange
        _project = new Project("Test", false, "test environment");
        _project.State = new StagingAreaState(_project);
        _change = new Change(new object(), _project);
    }

    // Happy flow :)

    [Fact]
    public void Should_Change_State_To_Staging_Area_When_Changes_Are_First_Added()
    {
        // Arrange
        Setup();
        // Act
        _project.AddChange(_change);
        var sut = _project.Changes.First()!.State;

        // Assert
        Assert.IsType<DomainServices.States.ChangesState.StagingAreaState>(sut);
    }
    [Fact]
    public void Should_Change_State_To_Head_When_Changes_Are_Committed()
    {
        // Arrange
        Setup();

        // Act
        _project.AddChange(_change);
        _project.CommitChanges("Test");
        var sut = _project.CurrentBranch.GetCurrentState();

        // Assert
        Assert.IsType<DomainServices.States.ChangesState.HeadState>(sut);
    }

    [Fact]
    public void Should_Change_State_Of_Changes_To_Head_But_Branch_Remains_On_Working_Directory_When_Changes_Are_Committed()
    {
        // Arrange
        Setup();

        // Act
        _project.AddChange(_change);
        _project.CommitChanges("Test");
        var sut = _project.State;

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
        var sut = _project.State;

        // Assert
        Assert.IsType<DomainServices.States.ChangesState.StagingAreaState>(sut);
    }

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
}
