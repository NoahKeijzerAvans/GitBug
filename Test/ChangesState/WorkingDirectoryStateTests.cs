using DomainServices.Context;
using DomainServices.Context.Commands;
using DomainServices.Interfaces.Change;
using DomainServices.States.ChangesState;
using DomainServices.Utils;

namespace Test.ChangesState;
public sealed class WorkingDirectoryStateTests
{
    private Change _change;
    private Project _project;

    public WorkingDirectoryStateTests()
    {
        _project = new Project("Test", false, "test environment");
        _project.State = new WorkingDirectoryState(_project);
        _change = new Change(new object(), _project);
    }
    

    // Happy flow :)

    [Fact]
    public void Should_Change_State_To_Staging_Area_When_Changes_Are_First_Added()
    {
        // Act
        _project.AddChange(_change);
        var sut = _project.CurrentBranch.Changes.First()!.State;

        // Assert
        Assert.IsType<StagingAreaState>(sut);
    }
    [Fact]
    public void Should_Change_State_To_Head_When_Changes_Are_Committed()
    {
        // Act
        _project.AddChange(_change);
        _project.CommitChanges("Test");
        var sut = _project.CurrentBranch.GetCurrentState();

        // Assert
        Assert.IsType<HeadState>(sut);
    }
    [Fact]
    public void Should_Change_State_Of_Changes_And_Branch_To_Head_When_Changes_Are_Committed()
    {
        // Act
        _project.AddChange(_change);
        _project.CommitChanges("Test");
        var sut = _project.CurrentBranch.GetCurrentState();

        // Assert
        Assert.IsType<HeadState>(sut);
    }

    // Unhappy flow :(

    [Fact]
    public void Should_Not_Change_State_When_Commit_Is_Called_With_No_Changes()
    {
        // Act
        _project.CommitChanges("no changes");
        var sut = _project.State;

        // Assert
        Assert.IsType<WorkingDirectoryState>(sut);
    }

    [Fact]
    public void Should_Throw_Invalid_Operation_Exception_When_Push_To_Remote_Is_Called()
    {
        // Act
        void TestCode() => _project.PushToRemote();
        // Assert
        Assert.Throws<InvalidOperationException>(TestCode);
    }
}
