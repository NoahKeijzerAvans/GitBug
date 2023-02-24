using DomainServices.Context;

namespace DomainServices.GitCommands.Commands;

public class GitCheckoutCommand : GitCommand
{
    public GitCheckoutCommand(Project context) : base(context)
    {
    }

    public override void Excecute(dynamic? param)
    {
        Context.CheckoutBranch(param);
    }
}