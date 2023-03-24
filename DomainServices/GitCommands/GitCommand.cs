using DomainServices.Context;

namespace DomainServices.GitCommands;

public abstract class GitCommand
{
    protected Project Context { get; }
    public abstract void Excecute(object? param);
    protected GitCommand(Project context)
    {
        Context = context;
    }
}