using DomainServices.Context;
using DomainServices.Context.VersionControl;
using DomainServices.States.ChangesState;

namespace Test.ChangesState;
public sealed class HeadStateTests
{
    
    private readonly Change _change;
    private readonly Project _project;
    public HeadStateTests()
    {
        _project = new Project("Test", false, "test environment");
        _project.State = new HeadState(_project);
        _change = new Change(new object(), _project);
    }
    // Unhappy flow :(

    [Fact]
    public void Should_Throw_Invalid_Operation_Exception_When_Push_To_Remote_Is_Called()
    {
        // Act
        void TestCode() => _project.PushToRemote();
        // Assert
        Assert.Throws<NotImplementedException>(TestCode);
    }
    [Fact]
    public void Should_Throw_Invalid_Operation_Exception_When_Add_Change_Is_Called()
    {
        // Act
        void TestCode() => _project.AddChange(_change);
        // Assert
        Assert.Throws<InvalidOperationException>(TestCode);
    }
    [Fact]
    public void Should_Throw_Invalid_Operation_Exception_When_Commit_Changes_Is_Called()
    {
        // Act
        void TestCode() => _project.CommitChanges("test");
        // Assert
        Assert.Throws<InvalidOperationException>(TestCode);
    }
}
