using DomainServices.Context;
using DomainServices.GitCommands.Commands;
using DomainServices.GitCommands.Commands.VersionControl;
using DomainServices.Utils;
using Moq;

namespace Test.GitCommands;
public class CommandControlTests
{
    private CommandControl Control;
    public CommandControlTests()
    {
        Control = new Mock<CommandControl>(new Project("Test")).Object;
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
        Control.ChooseCommand("git pull origin");

        // Assert
        Assert.IsType<GitPullCommand>(Control.Command);
    }
    [Fact]
    public void Should_Choose_Git_Checkout_Command_When_Instruction_Contains_git_checkout_With_Branch_Name()
    {
        // Act
        Control.ChooseCommand("git checkout slave");

        // Assert
        Assert.IsType<GitCheckoutCommand>(Control.Command);
    }
    [Fact]
    public void Should_Choose_Git_Push_Command_When_Instruction_Contains_git_push()
    {
        // Act
        try
        {
          Control.ChooseCommand("git push");
        }
        catch (Exception)
        {

        }

        // Assert
        Assert.IsType<GitPushCommand>(Control.Command);
    }
    [Fact]
    public void Should_Choose_Git_Pull_Command_When_Instruction_Contains_git_pull()
    {
        // Act
        Control.ChooseCommand("git pull");

        // Assert
        Assert.IsType<GitPullCommand>(Control.Command);
    }
}
