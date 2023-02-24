using DomainServices.Context;
using DomainServices.Utils;

namespace DomainServices.GitCommands.Commands;

public class GitPushCommand : GitCommand
{
    public GitPushCommand(Project context) : base(context)
    {
    }

    public override void Excecute(dynamic? param)
    {
        Context.PushToRemote();
    }
}