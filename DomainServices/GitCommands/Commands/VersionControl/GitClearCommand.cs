﻿using DomainServices.Context;

namespace DomainServices.GitCommands.Commands.VersionControl;

public class GitClearCommand : GitCommand
{
    public GitClearCommand(Project context) : base(context)
    {
    }

    public override void Excecute(object? param)
    {
        Console.Clear();
    }
}