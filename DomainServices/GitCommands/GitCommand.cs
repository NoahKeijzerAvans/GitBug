using DomainServices.Context;

namespace DomainServices.GitCommands;

public abstract class GitCommand
{
    public Project Context { get; }
    public abstract void Excecute(dynamic? param);
    protected GitCommand(Project context)
    {
        Context = context;
    }
}