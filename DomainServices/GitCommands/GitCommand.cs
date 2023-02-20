using DomainServices.Utils;

namespace DomainServices.GitCommands;

public abstract class GitCommand
{
    public abstract void Excecute(dynamic? param);
    protected GitCommand(ChangesTracker tracker)
    {
    }
}