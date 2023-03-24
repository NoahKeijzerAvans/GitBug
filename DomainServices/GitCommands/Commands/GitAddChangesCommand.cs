using DomainServices.Context;
using DomainServices.Context.VersionControl;
using DomainServices.Utils;
using System.Diagnostics;

namespace DomainServices.GitCommands.Commands;

public class GitAddChangesCommand : GitCommand
{
    public GitAddChangesCommand(Project context) : base(context)
    {
    }
    public override void Excecute(dynamic? change)
    {
        var gitCommand = "git";
        var gitAddArgument = @"add -A";
        var gitCommitArgument = @"commit ""explanations_of_changes""";
        var gitPushArgument = @"push our_remote";

        Process.Start(gitCommand, gitAddArgument);
        // Context.AddChange((Change?)change);
    }
}