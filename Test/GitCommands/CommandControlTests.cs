using DomainServices.Context;
using DomainServices.GitCommands.Commands;
using DomainServices.GitCommands.Commands.VersionControl;
using DomainServices.Utils;

namespace Test.GitCommands;
public class CommandControlTests
{
    private CommandControl Control;
    public CommandControlTests()
    {
        Control = new CommandControl(new Project("Test", false, "test environment"));
    }

    [Fact]
    public void Should_Choose_Git_Add_Command_When_Instruction_Contains_git_add()
    {
        // Act
        Control.ChooseCommand("git add");

        // Assert
        Assert.IsType<GitAddChangesCommand>(Control.Command);
    }

    [Fact]
    public void Should_Choose_Git_Commit_Command_When_Instruction_Contains_git_commit_With_Commit_Message()
    {
        // Act
        Control.ChooseCommand("git commit -m message");

        // Assert
        Assert.IsType<GitCommitCommand>(Control.Command);
    }
    [Fact]
    public void Should_Choose_Git_Pull_Command_When_Instruction_Contains_git_pull_origin()
    {
        // Act
        void TestCode() => Control.ChooseCommand("git pull origin");
        // Assert
        // Not implemented
        // Assert.IsType<GitPushCommand>(Control.Command);
        Assert.Throws<NotImplementedException>(TestCode);
    }
    [Fact]
    public void Should_Choose_Git_Checkout_Command_When_Instruction_Contains_git_checkout_With_Branch_Name()
    {
        // Act
        Control.ChooseCommand("git checkout -b slave");

        // Assert
        Assert.IsType<GitCheckoutCommand>(Control.Command);
    }
    [Fact]
    public void Should_Not_Choose_Git_Commit_Command_When_Instruction_Contains_git_commit_With_No_Commit_Message()
    {
        // Act
        Control.ChooseCommand("git commit");

        // Assert
        Assert.IsType<NoCommand>(Control.Command);
    }
    [Fact]
    public void Should_Not_Choose_Git_Push_Command_When_Instruction_Contains_git_push_With_No_Branch_Name()
    {
        // Act
        Control.ChooseCommand("git push");

        // Assert
        Assert.IsType<NoCommand>(Control.Command);
    }
    [Fact]
    public void Should_Not_Choose_Git_Pull_Command_When_Instruction_Contains_git_checkout_With_No_Branch_Name()
    {
        // Act
        Control.ChooseCommand("git push checkout");

        // Assert
        Assert.IsType<NoCommand>(Control.Command);
    }
}
